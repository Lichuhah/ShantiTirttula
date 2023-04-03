namespace ShantiTirttula.Server.Api.Domain.Interfaces.Models
{
    public interface IMicroController : IEntity
    {
        public IMicroControllerType Type { get; set; }
        public IList<ISensor> Sensors { get; set; }
        public IList<IDevice> Devices { get; set; }
    }
}
