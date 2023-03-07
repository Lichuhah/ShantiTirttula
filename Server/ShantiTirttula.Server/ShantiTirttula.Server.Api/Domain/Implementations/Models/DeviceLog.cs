using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Models
{
    public class DeviceLog : Entity, IDeviceLog
    {
        public virtual IMcAuth Auth { get; set; }
        public virtual IDevice Device { get; set; }
        public virtual float Value { get; set; }
    }
}
