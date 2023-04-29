using Quartz;
using Quartz.Impl;
using ShantiTirttula.Domain.Managers.Managment.Shedules;
using ShantiTirttula.Domain.Models.Managment.Shedules;
using ShantiTirttula.Repository.Managers.Managment.Shedules;
using ShantiTirttula.Repository.Models.Managment.Shedules;

namespace ShantiTirttula.Server.Api.Helpers.Quartz
{
    public class QuartzShedulerHelper
    {
        public static async void Start()
        {
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<TaskCreator>().Build();

            DateTime startTime = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 7, 13, 00);

            ITrigger trigger = TriggerBuilder.Create()  // создаем триггер
                .WithIdentity("sheduleTrigger", "mainGroup")     // идентифицируем триггер с именем и группой
                                                                 //.StartAt(startTime) // запуск сразу после начала выполнения
                .StartNow()
                .WithSimpleSchedule(x => x            // настраиваем выполнение действия
                    .WithIntervalInHours(24)          // через 1 минуту
                    .RepeatForever())                   // бесконечное повторение
                .Build();                               // создаем триггер

            await scheduler.ScheduleJob(job, trigger);
        }

        public static async void NewShedule(IShedule shedule)
        {
            ISheduleManager sheduleManager = new SheduleManager();
            ISheduleTaskManager sheduleTaskManager = new SheduleTaskManager();
            if (shedule.PeriodCounter == shedule.Period)
            {
                try
                {
                    SheduleTask startTask = new SheduleTask
                    {
                        StartDateTime = DateTime.UtcNow.Date + shedule.StartTime.TimeOfDay,
                        Command = shedule.StartCommand,
                        Auth = shedule.Auth
                    };
                    await sheduleTaskManager.SaveAsync(startTask);

                    SheduleTask endTask = new SheduleTask
                    {
                        StartDateTime = DateTime.UtcNow.Date + shedule.EndTime.TimeOfDay,
                        Command = shedule.EndCommand,
                        Auth = shedule.Auth
                    };
                    await sheduleTaskManager.SaveAsync(endTask);

                    shedule.LastExecutionTime = DateTime.UtcNow;

                    sheduleManager.Save(shedule);

                    HttpClient client = new HttpClient();
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, Environment.GetEnvironmentVariable("DISP_URL") + "/api/disp/" + shedule.Auth.Key);
                    HttpResponseMessage response = client.Send(request);
                    string result = response.Content.ReadAsStringAsync().Result;
                }
                catch (Exception)
                {

                }
            }
        }
    }
}
