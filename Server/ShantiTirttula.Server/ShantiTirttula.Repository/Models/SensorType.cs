using ShantiTirttula.Domain.Models;

namespace ShantiTirttula.Repository.Models
{
    public class SensorType : Entity, ISensorType
    {
        public virtual string Name { get; set; }
        public virtual IList<ISensor> Sensors { get; set; }
    }
}
