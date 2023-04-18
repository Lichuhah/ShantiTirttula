using Newtonsoft.Json;
using ShantiTirttula.Domain.Dto;
using ShantiTirttula.Domain.Dto.Models;
using ShantiTirttula.Server.Dispatcher.Http;
using ShantiTirttula.Server.Dispatcher.Sessions;

namespace ShantiTirttula.Server.Dispatcher.Producer
{
    public class TaskProducer : CommandProducer
    {
        List<SheduleTaskDto> Tasks;

        public TaskProducer() : base()
        {
            Tasks = new List<SheduleTaskDto>();
        }

        public override void LoadDataForSession(string token)
        {
            ApiResponse<List<SheduleTaskDto>> result = JsonConvert.DeserializeObject<ApiResponse<List<SheduleTaskDto>>>(HttpHelper.GetData("/api/ap/shedule-task", token));
            if (result.Success)
            {
                this.Tasks = result.Data;
            }
        }
        public override void Generate(Session session)
        {
            this.Commands.Clear();
            List<SheduleTaskDto> executedTasks = new List<SheduleTaskDto>();
            DateTime TimeNow = DateTime.UtcNow;
            foreach(SheduleTaskDto item in this.Tasks)
            {
                if(TimeNow > item.StartDateTime)
                {
                    this.Commands.Add(item.Command);
                    executedTasks.Add(item);
                }
            }    
            foreach(SheduleTaskDto item in executedTasks)
            {
                this.Tasks.Remove(item);
            }
        }

        public override string GetData()
        {
            return JsonConvert.SerializeObject(this.Tasks);
        }
    }
}
