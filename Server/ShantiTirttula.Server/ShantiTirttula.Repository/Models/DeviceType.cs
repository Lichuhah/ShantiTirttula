using ShantiTirttula.Domain.Models;

namespace ShantiTirttula.Repository.Models
{
    public class DeviceType : Entity, IDeviceType
    {
        public virtual string Name { get; set; }
        public virtual IList<IDevice> Devices { get; set; }
    }
}
