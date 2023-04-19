namespace ShantiTirttula.Domain.Models
{
    public interface ISensor : IEntityAuth
    {
        public int Number { get; set; }
        public IList<ISensorData> SensorDatas { get; set; }
        public IMicroController Controller { get; set; }
        public ISensorType Type { get; set; }
    }
}
