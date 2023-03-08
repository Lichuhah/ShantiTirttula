namespace ShantiTirttula.Server.Dispatcher.Models
{
    public class DispatcherTrigger
    {
        public ETriggerType Type { get; set; }
        public int SensorNumber { get; set; }
        public float TriggerValue { get; set; }
        public float DeviceValue { get; set; }
        public int Pin { get; set; }
        public bool IsPwm { get; set; }
    }
}
