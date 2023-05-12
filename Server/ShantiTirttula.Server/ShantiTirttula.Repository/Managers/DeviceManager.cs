using ShantiTirttula.Domain.Dto;
using ShantiTirttula.Domain.Dto.Models;
using ShantiTirttula.Domain.Managers;
using ShantiTirttula.Domain.Models;
using ShantiTirttula.Repository.Models;

namespace ShantiTirttula.Repository.Managers
{
    public class DeviceManager : EntityManager<IDevice>, IDeviceManager
    {
        public DeviceManager() : base()
        {

        }

        public override DeviceDto ConvertToDto(IDevice entity)
        {
            DeviceDto dto = new DeviceDto
            {
                Id = entity.Id,
                TypeName = entity.Type.Name,
                IsPwm = entity.IsAnalog,
                Pin = entity.Pin,
                IsAvailable = entity.IsAvailable
            };
            return dto;
        }

        public override IDevice ConvertFromDto(ApiDto<IDevice> data)
        {
            IDevice item;
            if (data.Id > 0)
                item = Get(data.Id);
            else
                item = new Device();

            DeviceDto dto = (DeviceDto)data;
            item.Pin = dto.Pin;
            item.IsAnalog = dto.IsPwm;
            item.IsAvailable = dto.IsAvailable;
            if (dto.ControllerId > 0)
            {
                item.Controller = new MicroControllerManager().Get(dto.ControllerId);
            }
            if (dto.TypeId > 0 && dto.TypeId != item.Type?.Id)
            {
                item.Type = new DeviceTypeManager().Get(dto.TypeId);
            }

            return item;
        }
    }
}
