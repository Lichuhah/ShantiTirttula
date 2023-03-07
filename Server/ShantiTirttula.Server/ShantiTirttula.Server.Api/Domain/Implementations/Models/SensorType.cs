using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Models
{
    public class SensorType : Entity, ISensorType
    {
        public virtual string Name { get; set; }
        public virtual IList<ISensor> Sensors { get; set; }
    }
}
