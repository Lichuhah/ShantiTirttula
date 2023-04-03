using ShantiTirttula.Domain.Models;

namespace ShantiTirttula.Domain.Dto.Models
{
    public class TriggerDto : ApiDtoWithAuth<ITrigger>
    {
        public int SensorId { get; set; }
        public int DeviceId { get; set; }
        public int Type { get; set; }
        public string? TypeName { get; set; }
        public int? SensorNumber { get; set; }
        public float TriggerValue { get; set; }
        public float DeviceValue { get; set; }
        public int? Pin { get; set; }
        public bool? IsPwm { get; set; }
    }
}
