namespace ShantiTirttula.Domain.Models
{
    public interface IDevice : IEntity
    {
        public IMicroController Controller { get; set; }
        public IDeviceType Type { get; set; }
        //public IList<IDeviceLog> Logs { get; set; }
        public int Pin { get; set; }
        public bool IsAnalog { get; set; }
    }
}
