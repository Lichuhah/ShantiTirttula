namespace ShantiTirttula.Domain.Models
{
    public interface ITrigger : IEntityAuth
    {
        public new IAuth Auth { get; set; }
        public ITriggerType Type { get; set; }
        public ISensor Sensor { get; set; }
        public IDevice Device { get; set; }
        public float TriggerValue { get; set; }
        public float DeviceValue { get; set; }
        public IList<ICommandLog> Logs { get; set; }
    }
}
