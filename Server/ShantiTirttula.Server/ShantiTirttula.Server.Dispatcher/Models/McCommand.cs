namespace ShantiTirttula.Server.Dispatcher.Models
{
    public class McCommand
    {
        public int TriggerId { get; set; }
        public int Pin { get; set; }
        public bool IsPwm { get; set; }
        public double Value { get; set; }
    }
}
