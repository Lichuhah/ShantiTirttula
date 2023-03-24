using ShantiTirttula.Server.Api.Controllers.Models;
using ShantiTirttula.Server.Api.Controllers.Models.Dto;
using ShantiTirttula.Server.Api.Domain.Implementations.Models;
using ShantiTirttula.Server.Api.Domain.Interfaces.Managers;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Managers
{
    public class DeviceManager : EntityManager<IDevice>, IDeviceManager
    {
        public DeviceManager() : base()
        {

        }

        public override DeviceDto ConvertToDto(IDevice entity)
        {
            DeviceDto dto = new DeviceDto();
            dto.Id = entity.Id;          
            dto.TypeName = entity.Controller.Type.Name;
            dto.IsPwm = entity.IsAnalog;
            dto.Pin = entity.Pin;
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
            if (dto.ControllerId > 0)
            {
                item.Controller = new MicroControllerManager().Get(dto.ControllerId);
            }
            if(dto.TypeId>0 && dto.TypeId != item.Type?.Id)
            {
                item.Type = new DeviceTypeManager().Get(dto.TypeId);
            }

            return item;
        }

        public override bool CheckUser(IDevice entity, IUser user)
        {
            return true;
        }
    }
}
