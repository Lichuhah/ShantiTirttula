namespace ShantiTirttula.Server.Api.Domain.Interfaces.Models
{
    public interface ISensorData : IEntity
    {
        public double Value { get; set; }
        public DateTime DateTime { get; set; }
    }
}
