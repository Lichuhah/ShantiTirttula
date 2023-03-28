using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Controllers.Models.Dto
{
    public class SensorDataDto : ApiDtoWithAuth<ISensorData>
    {
        public int SensorId { get; set; }
        public double Value { get; set; }
    }
}
