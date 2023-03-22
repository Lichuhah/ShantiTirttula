﻿using ShantiTirttula.Server.Api.Controllers.Models;
using ShantiTirttula.Server.Api.Controllers.Models.Dto;
using ShantiTirttula.Server.Api.Domain.Implementations.Models;
using ShantiTirttula.Server.Api.Domain.Interfaces.Managers;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Managers
{
    public class TriggerManager : EntityManager<ITrigger>, ITriggerManager
    {
        public TriggerManager() : base()
        {

        }

        public override TriggerDto ConvertToDto(ITrigger entity)
        {
            TriggerDto dto = new TriggerDto() {
                Id = entity.Id,
                SensorNumber = entity.Sensor.Number,
                TriggerValue = entity.TriggerValue,
                Type = entity.Type.Id,
                TypeName = entity.Type.Name,
                DeviceValue = entity.DeviceValue,
                IsPwm = entity.Device.IsAnalog,
                Pin = entity.Device.Pin,
                SensorId = entity.Sensor.Id,
                DeviceId = entity.Device.Id
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
            item.DeviceValue = dto.DeviceValue;
            item.TriggerValue = dto.TriggerValue;
            item.Device = new DeviceManager().Get(dto.DeviceId);
            item.Sensor = new SensorManager().Get(dto.SensorId);
            item.Type = new TriggerTypeManager().Get(dto.Type);

            return item;
        }

        public override bool CheckUser(ITrigger entity, IUser user)
        {
            return entity.Auth.User.Id == user.Id;
        }
    }
}
