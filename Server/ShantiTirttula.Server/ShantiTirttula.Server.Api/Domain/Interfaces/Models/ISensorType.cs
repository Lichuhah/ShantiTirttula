namespace ShantiTirttula.Server.Api.Domain.Interfaces.Models
{
    public interface ISensorType : IEntity
    {
        public string Name { get; set; }
        public IList<ISensor> Sensors { get; set; }
    }
}
