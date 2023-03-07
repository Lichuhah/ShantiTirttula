namespace ShantiTirttula.Server.Api.Domain.Interfaces.Models
{
    public interface IDeviceLog : IEntity
    {
        public IMcAuth Auth { get; set; }
        public IDevice Device { get; set; }
        public float Value { get; set; }
    }
}
