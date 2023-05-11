using ShantiTirttula.Domain.Enums;
using ShantiTirttula.Domain.Models;

namespace ShantiTirttula.Repository.Models
{
    public class SensorType : Entity, ISensorType
    {
        public virtual string Name { get; set; }
        public virtual string Unit { get; set; }
        public virtual IList<ISensor> Sensors { get; set; }
        public virtual double MaxValue { get; set; }
        public virtual double MinValue { get; set; }
        public virtual double Power { get; set; }
        public virtual ESensorDataAlgorithm Algorithm { get; set; }
        public virtual bool IsReverse { get; set; }
    }
}
