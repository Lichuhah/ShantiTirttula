namespace ShantiTirttula.Server.Api.Domain.Interfaces.Models
{
    public interface IController : IEntity
    {
        public string Mac { get; set; }
        public IControllerType Type { get; set; }
        public IList<ISensor> Sensors { get; set; }
        public IList<IDevice> Devices { get; set; }
    }
}
