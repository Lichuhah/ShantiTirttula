using ShantiTirttula.Domain.Models;

namespace ShantiTirttula.Domain.Dto.Models
{
    public class SensorDto : ApiDtoWithAuth<ISensor>
    {
        public int ControllerId { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public int Number { get; set; }
    }
}
