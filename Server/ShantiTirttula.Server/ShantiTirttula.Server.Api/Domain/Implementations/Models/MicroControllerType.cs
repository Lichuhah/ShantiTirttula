using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Models
{
    public class MicroControllerType : Entity, IMicroControllerType
    {
        public virtual string Name { get; set; }
        public virtual IList<IMicroController> Controllers { get; set; }
    }
}
