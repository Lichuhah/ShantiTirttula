using ShantiTirttula.Server.Api.Domain.Interfaces.Managers;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Managers
{
    public class SensorDataManager : EntityManager<ISensorData>, ISensorDataManager
    {
        public SensorDataManager(NHibernate.ISession session) : base(session)
        {

        }
    }
}
