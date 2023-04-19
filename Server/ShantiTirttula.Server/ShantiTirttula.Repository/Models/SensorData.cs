using ShantiTirttula.Domain.Models;

namespace ShantiTirttula.Repository.Models
{
    public class SensorData : Entity, ISensorData
    {
        public virtual double Value { get; set; }
        public virtual ISensor Sensor { get; set; }
        public virtual IAuth Auth { get; set; }
        public virtual DateTime DateTime { get; set; }
    }
}
