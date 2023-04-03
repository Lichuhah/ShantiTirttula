using ShantiTirttula.Domain.Models;

namespace ShantiTirttula.Repository.Models
{
    public class MicroController : Entity, IMicroController
    {
        public virtual IMicroControllerType Type { get; set; }
        public virtual IList<ISensor> Sensors { get; set; }
        public virtual IList<IDevice> Devices { get; set; }
    }
}
