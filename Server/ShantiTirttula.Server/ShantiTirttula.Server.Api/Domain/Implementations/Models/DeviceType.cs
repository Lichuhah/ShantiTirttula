using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Models
{
    public class DeviceType : Entity, IDeviceType
    {
        public virtual string Name { get; set; }
        public virtual IList<IDevice> Devices { get; set; }
    }
}
