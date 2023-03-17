using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Models
{
    public class Device : Entity, IDevice
    {
        public virtual IMicroController Controller { get; set; }
        public virtual IDeviceType Type { get; set; }
        public virtual IList<IDeviceLog> Logs { get; set; }
        public virtual int Pin { get; set; }
        public virtual bool IsAnalog { get; set; }
    }
}
