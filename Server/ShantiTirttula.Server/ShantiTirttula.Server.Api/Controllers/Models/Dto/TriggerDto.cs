using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Controllers.Models.Dto
{
    public class TriggerDto : ApiDto<ITrigger>
    {
        public int AuthId { get; set; }
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
