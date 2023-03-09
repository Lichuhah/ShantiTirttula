namespace ShantiTirttula.Server.Api.Controllers.Models.Output
{
    public class TriggerOutput
    {
        public int Type { get; set; }
        public int SensorNumber { get; set; }
        public float TriggerValue { get; set; }
        public float DeviceValue { get; set; }
        public int Pin { get; set; }
        public bool IsPwm { get; set; }
    }
}
