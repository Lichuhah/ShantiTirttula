using ShantiTirttula.Server.Api.Controllers.Models;
using ShantiTirttula.Server.Api.Controllers.Models.Dto;
using ShantiTirttula.Server.Api.Domain.Implementations.Models;
using ShantiTirttula.Server.Api.Domain.Interfaces.Managers;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Managers
{
    public class SensorManager : EntityManager<ISensor>, ISensorManager
    {
        public SensorManager() : base()
        {

        }

        public override SensorDto ConvertToDto(ISensor entity)
        {
            SensorDto dto = new SensorDto();
            dto.Id = entity.Id;
            dto.TypeName = entity.Type.Name;
            dto.Number = entity.Number;
            return dto;
        }

        public override ISensor ConvertFromDto(ApiDto<ISensor> data)
        {
            ISensor item;
            if (data.Id > 0)
                item = Get(data.Id);
            else
                item = new Sensor();

            SensorDto dto = (SensorDto)data;
            if (dto.ControllerId > 0)
            {
                item.Controller = new MicroControllerManager().Get(dto.ControllerId);
            }
            if (dto.TypeId > 0 && dto.TypeId != item.Type?.Id)
            {
                item.Type = new SensorTypeManager().Get(dto.TypeId);
            }

            return item;
        }
    }
}
