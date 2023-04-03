namespace ShantiTirttula.Domain.Models
{
    public interface IMicroController : IEntity
    {
        public IMicroControllerType Type { get; set; }
        public double Voltage { get; set; }
        public int AdcMax { get; set; }
        public IList<ISensor> Sensors { get; set; }
        public IList<IDevice> Devices { get; set; }
    }
}
