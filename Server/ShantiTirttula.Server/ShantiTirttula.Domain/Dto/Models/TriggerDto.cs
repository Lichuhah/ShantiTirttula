using ShantiTirttula.Domain.Enums;
using ShantiTirttula.Domain.Models;

namespace ShantiTirttula.Domain.Dto.Models
{
    public class TriggerDto : ApiDtoWithAuth<ITrigger>
    {
        public int SensorId { get; set; }
        public ETriggerType Type { get; set; }
        public string? TypeName { get; set; }
        public int? SensorNumber { get; set; }
        public string SensorUnit { get; set; }
        public string SensorName { get; set; }
        public float TriggerValue { get; set; }
        public CommandDto Command { get; set; }
        public bool IsAutonomy { get; set; }
    }
}
