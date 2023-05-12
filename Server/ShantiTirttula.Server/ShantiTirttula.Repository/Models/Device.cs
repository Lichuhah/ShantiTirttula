using ShantiTirttula.Domain.Models;

namespace ShantiTirttula.Repository.Models
{
    public class Device : Entity, IDevice
    {
        public virtual IMicroController Controller { get; set; }
        public virtual IDeviceType Type { get; set; }
        public virtual int Pin { get; set; }
        public virtual bool IsAnalog { get; set; }
        public virtual bool IsAvailable { get; set; }
    }
}
