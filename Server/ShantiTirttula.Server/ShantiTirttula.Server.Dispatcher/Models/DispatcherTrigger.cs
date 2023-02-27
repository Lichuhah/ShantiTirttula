namespace ShantiTirttula.Server.Dispatcher.Models
{
    public class DispatcherTrigger
    {
        public string Serial { get; set; }
        public int SensorId { get; set; }
        public float TriggerValue { get; set; }
        public int DeviceId { get; set; }
        public int Pin { get; set; }
        public bool IsPwm { get; set; }
        public float LeftCommandValue { get; set; }
        public float RightCommandValue { get; set; }
        public bool IsCheck { get; set; }
    }
}
