using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Models
{
    public class MicroController : Entity, IMicroController
    {
        public virtual IMicroControllerType Type { get; set; }
        public virtual IList<ISensor> Sensors { get; set; }
        public virtual IList<IDevice> Devices { get; set; }
    }
}
