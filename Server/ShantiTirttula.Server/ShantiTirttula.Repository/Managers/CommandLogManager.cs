using ShantiTirttula.Domain.Dto;
using ShantiTirttula.Domain.Managers;
using ShantiTirttula.Domain.Models;
using ShantiTirttula.Domain.Dto.Models;
using ShantiTirttula.Repository.Models;

namespace ShantiTirttula.Repository.Managers
{
    public class CommandLogManager : EntityManager<ICommandLog>, ICommandLogManager
    {
        public CommandLogManager() : base()
        {

        }

        //public override CommandLogDto ConvertToDto(ICommandLog entity)
        //{
        //    CommandLogDto dto = new CommandLogDto();
        //    dto.Id = entity.Id;
        //    dto.AuthId = entity.Auth.Id;
        //    dto.Value = entity.Trigger.DeviceValue;
        //    dto.DevicePin = entity.Trigger.Device.Pin;
        //    dto.DeviceTypeName = entity.Trigger.Device.Type.Name;
        //    dto.SensorNumber = entity.Trigger.Sensor.Number;
        //    dto.SensorTypeName = entity.Trigger.Sensor.Type.Name;
        //    dto.TriggerTypeName = entity.Trigger.Type.Name;
        //    dto.DateTime = entity.DateTime;
        //    return dto;
        //}

        //public override ICommandLog ConvertFromDto(ApiDto<ICommandLog> data)
        //{
        //    ICommandLog item;
        //    if (data.Id > 0)
        //        item = Get(data.Id);
        //    else
        //        item = new CommandLog();

        //    CommandLogDto dto = (CommandLogDto)data;
        //    //if (dto.AuthId > 0)
        //    //{
        //    //    item.Auth = new AuthManager().Get(dto.AuthId);
        //    //}
        //    if (dto.TriggerId > 0)
        //    {
        //        item.Trigger = new TriggerManager().Get(dto.TriggerId);
        //    }
        //    item.DateTime = DateTime.UtcNow;

        //    return item;
        //}
    }
}
