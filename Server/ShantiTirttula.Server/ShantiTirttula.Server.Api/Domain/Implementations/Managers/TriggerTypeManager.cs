using ShantiTirttula.Server.Api.Domain.Interfaces.Managers;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Managers
{
    public class TriggerTypeManager : EntityManager<ITriggerType>, ITriggerTypeManager
    {
        public TriggerTypeManager(NHibernate.ISession session) : base(session)
        {

        }
    }
}
