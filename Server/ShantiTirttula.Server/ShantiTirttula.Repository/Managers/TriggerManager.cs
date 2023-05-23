using ShantiTirttula.Domain.Dto;
using ShantiTirttula.Domain.Dto.Models;
using ShantiTirttula.Domain.Managers;
using ShantiTirttula.Domain.Models;
using ShantiTirttula.Repository.Helpers;
using ShantiTirttula.Repository.Managers.Managment.Shedules;
using ShantiTirttula.Repository.Models;

namespace ShantiTirttula.Repository.Managers
{
    public class TriggerManager : EntityManager<ITrigger>, ITriggerManager
    {
        public TriggerManager() : base()
        {

        }

        //public override bool Delete(ITrigger entity)
        //{
        //    ICommandLogManager logManager = new CommandLogManager();
        //    foreach(ICommandLog log in entity.)
        //    return Repository.Delete(entity);
        //}

        public override TriggerDto ConvertToDto(ITrigger entity)
        {
            TriggerDto dto = new TriggerDto()
            {
                Id = entity.Id,
                SensorNumber = entity.Sensor.Number,
                TriggerValue = (float)Math.Round(SensorAlgorithmHelper.GetValue(entity.TriggerValue, entity.Sensor),1),
                Type = (Domain.Enums.ETriggerType)entity.Type.Id,
                TypeName = entity.Type.Name,
                SensorId = entity.Sensor.Id,
                SensorUnit = entity.Sensor.Type.Unit,
                Command = new SheduleCommandManager().ConvertToDto(entity.Command),
                SensorName = entity.Sensor.Type.Name,
                IsAutonomy = entity.IsAutonomy
            };
            return dto;
        }

        public override ITrigger ConvertFromDto(ApiDto<ITrigger> data)
        {
            ITrigger item;
            if (data.Id > 0)
                item = Get(data.Id);
            else
                item = new Trigger();

            TriggerDto dto = (TriggerDto)data;
            item.TriggerValue = dto.TriggerValue;
            if (dto.SensorId > 0)
                item.Sensor = new SensorManager().Get(dto.SensorId);
            if (dto.Type > 0)
                item.Type = new TriggerTypeManager().Get((int)dto.Type);
            if (dto.AuthId > 0)
                item.Auth = new AuthManager().Get(dto.AuthId);
            return item;
        }
    }
}
