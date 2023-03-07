using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Models
{
    public class Controller : Entity, IController
    {
        public virtual string Mac { get; set; }
        public virtual IControllerType Type { get; set; }
        public virtual IList<ISensor> Sensors { get; set; }
        public virtual IList<IDevice> Devices { get; set; }
    }
}
