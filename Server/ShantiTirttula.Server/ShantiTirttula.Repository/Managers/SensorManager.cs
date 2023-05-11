using ShantiTirttula.Domain.Dto;
using ShantiTirttula.Domain.Dto.Models;
using ShantiTirttula.Domain.Managers;
using ShantiTirttula.Domain.Models;
using ShantiTirttula.Repository.Models;

namespace ShantiTirttula.Repository.Managers
{
    public class SensorManager : EntityManager<ISensor>, ISensorManager
    {
        public SensorManager() : base()
        {

        }

        public override SensorDto ConvertToDto(ISensor entity)
        {
            SensorDto dto = new SensorDto
            {
                Id = entity.Id,
                TypeName = entity.Type.Name,
                Number = entity.Number,
                AuthId = entity.Auth.Id,
                Unit = entity.Type.Unit,
            };
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
