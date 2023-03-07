namespace ShantiTirttula.Server.Api.Domain.Interfaces.Models
{
    public interface ITrigger : IEntity
    {
        public ITriggerType Type { get; set; }
        public ISensor Sensor { get; set; }
        public IDevice Device { get; set; }
        public IMcAuth Auth { get; set; }
        public float TriggerValue { get; set; }
        public float DeviceValue { get; set; }
    }
}
