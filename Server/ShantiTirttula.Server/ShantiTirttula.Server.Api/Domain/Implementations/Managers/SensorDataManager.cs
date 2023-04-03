using ShantiTirttula.Server.Api.Controllers.Models.Dto;
using ShantiTirttula.Server.Api.Controllers.Models;
using ShantiTirttula.Server.Api.Domain.Implementations.Models;
using ShantiTirttula.Server.Api.Domain.Interfaces.Managers;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Managers
{
    public class SensorDataManager : EntityManager<ISensorData>, ISensorDataManager
    {
        public SensorDataManager() : base()
        {

        }

        public override SensorDataDto ConvertToDto(ISensorData entity)
        {
            SensorDataDto dto = new SensorDataDto();
            dto.Id = entity.Id;
            dto.AuthId = entity.Auth.Id;
            dto.SensorId = entity.Sensor.Id;
            dto.Value = entity.Value;
            return dto;
        }

        public override ISensorData ConvertFromDto(ApiDto<ISensorData> data)
        {
            ISensorData item;
            if (data.Id > 0)
                item = Get(data.Id);
            else
                item = new SensorData();

            SensorDataDto dto = (SensorDataDto)data;
            item.Value = dto.Value;
            if (dto.AuthId > 0 && dto.AuthId != item.Auth?.Id)
            {
                item.Auth = new AuthManager().Get(dto.AuthId);
            }
            if (dto.SensorId > 0 && dto.SensorId != item.Sensor?.Id)
            {
                item.Sensor = new SensorManager().Get(dto.SensorId);
            }

            return item;
        }
    }
}
