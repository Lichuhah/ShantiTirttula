using Newtonsoft.Json;
using ShantiTirttula.Domain.Dto;
using ShantiTirttula.Domain.Dto.Models;
using ShantiTirttula.Server.Dispatcher.Http;

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
        public override void Generate(List<Dispatcher.Models.McSensorData> datas)
        {
            this.Commands.Clear();
            DateTime TimeNow = DateTime.UtcNow;
            foreach(SheduleTaskDto item in this.Tasks)
            {
                if(TimeNow > item.StartDateTime)
                {
                    this.Commands.Add(item.Command);
                    this.Tasks.Remove(item);
                }
            }           
        }
    }
}
