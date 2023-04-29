using Newtonsoft.Json;
using ShantiTirttula.Domain.Dto;
using ShantiTirttula.Domain.Dto.Models;
using ShantiTirttula.Domain.Enums;
using ShantiTirttula.Server.Dispatcher.Http;
using ShantiTirttula.Server.Dispatcher.Sessions;

namespace ShantiTirttula.Server.Dispatcher.Producer
{
    public class TriggerProducer : CommandProducer
    {
        List<TriggerDto> Triggers;

        public TriggerProducer() : base()
        {
            Triggers = new List<TriggerDto>();
        }

        public override void LoadDataForSession(string token)
        {
            ApiResponse<List<TriggerDto>> result = JsonConvert.DeserializeObject<ApiResponse<List<TriggerDto>>>(HttpHelper.GetData("/api/ap/triggers", token));
            if (result.Success)
            {
                this.Triggers = result.Data;
            }
        }
        public override void Generate(Session session)
        {
            this.Commands.Clear();
            foreach (SensorDataDto sensor in session.SensorsData.Last())
            {
                List<TriggerDto> triggers = Triggers.Where(x => x.SensorNumber == sensor.SensorId).ToList();
                foreach (TriggerDto trigger in triggers)
                {
                    CreateCommand(session, sensor, trigger);
                }
            }
        }

        private void CreateCommand(Session session, SensorDataDto sensor, TriggerDto trigger)
        {
            bool isTrigger = false;
            switch (trigger.Type)
            {
                case ETriggerType.More: isTrigger = sensor.Value > trigger.TriggerValue; break;
                case ETriggerType.Less: isTrigger = sensor.Value < trigger.TriggerValue; break;
            }
            if (isTrigger)
            {
                if (session.DeviceValues.FirstOrDefault(x => x.Pin == trigger.Command.Pin)?.Value != trigger.Command.Value)
                {
                    Commands.Add(trigger.Command);
                }
            }
        }

        public override string GetData()
        {
            return JsonConvert.SerializeObject(this.Triggers);
        }
    }
}
