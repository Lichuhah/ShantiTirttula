using ShantiTirttula.Domain.Enums;

namespace ShantiTirttula.Domain.Models
{
    public interface ISensorType : IEntity
    {
        public string Name { get; set; }
        public string Unit { get; set; }
        public double MaxValue { get; set; }
        public double MinValue { get; set; }
        public double Power { get; set; }
        public IList<ISensor> Sensors { get; set; }
        public ESensorDataAlgorithm Algorithm { get; set; }
        public bool IsReverse { get; set; }
    }
}
