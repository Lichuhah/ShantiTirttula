namespace ShantiTirttula.Domain.Models
{
    public interface ISensorData : IEntityAuth
    {
        public double Value { get; set; }
        public ISensor Sensor { get; set; }
        public new IAuth Auth { get; set; }
        public DateTime DateTime { get; set; }
    }
}
