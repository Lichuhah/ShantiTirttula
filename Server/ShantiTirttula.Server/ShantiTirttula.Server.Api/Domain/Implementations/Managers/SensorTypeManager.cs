using ShantiTirttula.Server.Api.Domain.Interfaces.Managers;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Managers
{
    public class SensorTypeManager : EntityManager<ISensorType>, ISensorTypeManager
    {
        public SensorTypeManager(NHibernate.ISession session) : base(session)
        {

        }
    }
}
