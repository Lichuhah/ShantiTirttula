using Microsoft.AspNetCore.Http;
using NHibernate.Util;
using Quartz;
using ShantiTirttula.Domain.Dto.Models;
using ShantiTirttula.Domain.Managers;
using ShantiTirttula.Domain.Managers.Managment.Shedules;
using ShantiTirttula.Domain.Models;
using ShantiTirttula.Domain.Models.Managment.Shedules;
using ShantiTirttula.Repository.Helpers;
using ShantiTirttula.Repository.Managers.Managment.Shedules;
using ShantiTirttula.Repository.Models.Managment.Shedules;

namespace ShantiTirttula.Server.Api.Helpers.Quartz
{
    public class TaskCreator : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            clearTasks();
            ISheduleManager sheduleManager = new SheduleManager();
            List<SheduleDto> shedules = sheduleManager.All().Select(x => (SheduleDto)sheduleManager.ConvertToDto(x)).ToList();
            using (NHibernate.ISession session = NHibernateHelper.GetSessionFactory().OpenSession())
            {
                foreach (SheduleDto shedule in shedules)
                {
                    using (var tx = session.BeginTransaction())
                    {
                        try
                        {
                            ISheduleTask newTask = new SheduleTask();
                            newTask.Command = session.Get<SheduleCommand>(shedule.StartCommandId);
                            newTask.StartDateTime = DateTime.UtcNow.Date + shedule.StartTime.TimeOfDay;
                            session.Save(newTask);
                        }
                        catch (Exception ex)
                        {
                            tx.Rollback();
                        }
                        finally
                        {
                            tx.Commit();
                        }
                    }
                    using (var tx = session.BeginTransaction())
                    {
                        try
                        {
                            ISheduleTask newTask = new SheduleTask();
                            newTask.Command = session.Get<SheduleCommand>(shedule.EndCommandId);
                            newTask.StartDateTime = DateTime.UtcNow.Date + shedule.EndTime.TimeOfDay;
                            session.Save(newTask);
                        }
                        catch (Exception ex)
                        {
                            tx.Rollback();
                        }
                        finally
                        {
                            tx.Commit();
                        }
                    }
                    using (var tx = session.BeginTransaction())
                    {
                        try
                        {
                            IShedule item = session.Get<Shedule>(shedule.Id);
                            item.LastExecutionTime = DateTime.UtcNow;
                            session.Save(item);
                        }
                        catch (Exception ex)
                        {
                            tx.Rollback();
                        }
                        finally
                        {
                            tx.Commit();
                        }
                    }
                }             
            }
        }

        private async Task SaveTask(NHibernate.ISession session, SheduleDto shedule)
        {
            ISheduleTask newTask = new SheduleTask();
            newTask.Command = session.Get<SheduleCommand>(shedule.StartCommandId);
            newTask.StartDateTime = DateTime.UtcNow.Date + shedule.StartTime.TimeOfDay;

        }

        [Obsolete]
        private void clearTasks()
        {
            ISheduleTaskManager sheduleTaskManager = new SheduleTaskManager();
            sheduleTaskManager.All().ForEach(task =>
            {
                sheduleTaskManager.Delete(task);
            });
        }
    }
}
