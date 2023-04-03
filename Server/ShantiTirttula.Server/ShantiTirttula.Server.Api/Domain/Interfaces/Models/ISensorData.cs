namespace ShantiTirttula.Server.Api.Domain.Interfaces.Models
{
    public interface ISensorData : IEntity
    {
        public double Value { get; set; }
        public ISensor Sensor { get; set; }
        public IAuth Auth { get; set; }
    }
}
