using ShantiTirttula.Server.Api.Domain.Interfaces.Managers;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Managers
{
    public class SensorManager : EntityManager<ISensor>, ISensorManager
    {
        public SensorManager() : base()
        {

        }
    }
}
