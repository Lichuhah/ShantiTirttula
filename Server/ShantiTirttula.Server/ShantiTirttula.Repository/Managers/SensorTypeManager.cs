using ShantiTirttula.Domain.Managers;
using ShantiTirttula.Domain.Models;

namespace ShantiTirttula.Repository.Managers
{
    public class SensorTypeManager : EntityManager<ISensorType>, ISensorTypeManager
    {
        public SensorTypeManager() : base()
        {

        }
    }
}
