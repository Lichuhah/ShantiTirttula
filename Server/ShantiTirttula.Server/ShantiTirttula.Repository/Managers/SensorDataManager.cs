using ShantiTirttula.Domain.Models;
using ShantiTirttula.Domain.Dto;
using ShantiTirttula.Domain.Managers;
using ShantiTirttula.Domain.Dto.Models;
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
            if(dto.AuthId > 0)
            {
                item.Auth = new AuthManager().Get(dto.AuthId);
            
                if (dto.SensorId > 0 && dto.SensorId != item.Sensor?.Id)
                {
                    item.Sensor = item.Auth.Product.Controller.Sensors.First(x=>x.Number == dto.SensorId);
                }
            }

            return item;
        }
    }
}
