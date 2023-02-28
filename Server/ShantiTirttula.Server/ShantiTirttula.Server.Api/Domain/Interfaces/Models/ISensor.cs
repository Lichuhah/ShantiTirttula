using ShantiTirttula.Server.Api.Domain.Implementations.Models;

namespace ShantiTirttula.Server.Api.Domain.Interfaces.Models
{
    public interface ISensor : IEntity
    {
        public int Number { get; set; }
        public IList<ISensorData> SensorDatas { get; set; }
        public IMcAuth Auth { get; set; }
    }
}
