using ShantiTirttula.Domain.Dto;
using ShantiTirttula.Domain.Dto.Models;
using ShantiTirttula.Domain.Managers;
using ShantiTirttula.Domain.Models;
using ShantiTirttula.Repository.Models;

namespace ShantiTirttula.Repository.Managers
{
    public class SensorDataManager : EntityManager<ISensorData>, ISensorDataManager
    {
        public SensorDataManager() : base()
        {

        }

        public override SensorDataDto ConvertToDto(ISensorData entity)
        {
            SensorDataDto dto = new SensorDataDto
            {
                Id = entity.Id,
                AuthId = entity.Auth.Id,
                SensorId = entity.Sensor.Id,
                Value = entity.Value,
                DateTime = entity.DateTime
            };
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
            item.DateTime = dto.DateTime;
            if (dto.AuthId > 0)
            {
                item.Auth = new AuthManager().Get(dto.AuthId);

                if (dto.SensorId > 0 && dto.SensorId != item.Sensor?.Id)
                {
                    item.Sensor = item.Auth.Product.Controller.Sensors.First(x => x.Number == dto.SensorId);
                }
            }

            return item;
        }
    }
}
