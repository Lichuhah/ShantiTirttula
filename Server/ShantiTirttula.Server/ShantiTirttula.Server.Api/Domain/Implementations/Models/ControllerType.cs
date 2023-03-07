using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Models
{
    public class ControllerType : Entity, IControllerType
    {
        public virtual string Name { get; set; }
        public virtual IList<IController> Controllers { get; set; }
    }
}
