using ShantiTirttula.Domain.Models;

namespace ShantiTirttula.Repository.Models
{
    public class MicroControllerType : Entity, IMicroControllerType
    {
        public virtual string Name { get; set; }
        public virtual IList<IMicroController> Controllers { get; set; }
    }
}
