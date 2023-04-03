using ShantiTirttula.Domain.Models;

namespace ShantiTirttula.Domain.Dto.Models
{
    public class SensorDataDto : ApiDtoWithAuth<ISensorData>
    {
        public int SensorId { get; set; }
        public double Value { get; set; }
    }
}
