namespace ShantiTirttula.Server.Dispatcher.Models
{
    public class DispatcherTrigger
    {
        public int Id { get; set; }
        public int AuthId { get; set; }
        public ETriggerType Type { get; set; }
        public int SensorNumber { get; set; }
        public float TriggerValue { get; set; }
        public float DeviceValue { get; set; }
        public int Pin { get; set; }
        public bool IsPwm { get; set; }
    }
}
