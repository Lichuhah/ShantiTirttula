﻿using ShantiTirttula.Domain.Dto;
using ShantiTirttula.Domain.Dto.Models;
using ShantiTirttula.Domain.Managers.Managment.Shedules;
using ShantiTirttula.Domain.Models.Managment.Shedules;
using ShantiTirttula.Repository.Models.Managment.Shedules;

namespace ShantiTirttula.Repository.Managers.Managment.Shedules
{
    public class SheduleCommandManager : EntityManager<ISheduleCommand>, ISheduleCommandManager
    {
        public SheduleCommandManager() : base()
        {

        }

        public override CommandDto ConvertToDto(ISheduleCommand entity)
        {
            CommandDto dto = new CommandDto
            {
                Id = entity.Id,
                Value = entity.Value,
                IsPwm = entity.Device.IsAnalog,
                Pin = entity.Device.Pin,
                AuthId = entity.Auth.Id,
                DeviceId = entity.Device.Id,
                Name = entity.Name
            };
            return dto;
        }

        public override ISheduleCommand ConvertFromDto(ApiDto<ISheduleCommand> data)
        {
            ISheduleCommand item;
            if (data.Id > 0)
                item = Get(data.Id);
            else
                item = new SheduleCommand();

            CommandDto dto = (CommandDto)data;

            if (dto.AuthId > 0)
            {
                item.Auth = new AuthManager().Get(dto.AuthId);
                //item.Device = item.Auth.Product.Controller.Devices.First(x => x.Pin == dto.Pin);
            }
            if (dto.DeviceId > 0)
                item.Device = new DeviceManager().Get(dto.DeviceId);

            item.Value = (int)dto.Value;
            item.Name = dto.Name;
            return item;
        }
    }
}
