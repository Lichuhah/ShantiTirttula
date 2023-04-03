using ShantiTirttula.Domain.Models;

namespace ShantiTirttula.Repository.Models
{
    public class Sensor : Entity, ISensor
    {
        public virtual int Number { get; set; }
        public virtual IList<ISensorData> SensorDatas { get; set; }
        public virtual IMicroController Controller { get; set; }
        public virtual ISensorType Type { get; set; }
    }
}
