using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Models
{
    public class SensorData : Entity, ISensorData
    {
        public virtual double Value { get; set; }
        public virtual ISensor Sensor { get; set; }
        public virtual IAuth Auth { get; set; }
    }
}
