namespace ShantiTirttula.Server.Api.Domain.Interfaces.Models
{
    public interface IDeviceType : IEntity
    {
        public string Name { get; set; }
        public IList<IDevice> Devices { get; set; } 
    }
}
