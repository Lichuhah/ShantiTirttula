using ShantiTirttula.Domain.Models;

namespace ShantiTirttula.Domain.Dto.Models
{
    public class CommandLogDto : ApiDtoWithAuth<ICommandLog>
    {
        public int TriggerId { get; set; }
        public double Value { get; set; }
        public int? SensorNumber { get; set; }
        public string? SensorTypeName { get; set; }
        public int? DevicePin { get; set; }
        public string? DeviceTypeName { get; set; }
        public string? TriggerTypeName { get; set; }
        public DateTime? DateTime { get; set; }
        public int? Pin { get; set; }
        public bool? IsPwm { get; set; }
    }
}
