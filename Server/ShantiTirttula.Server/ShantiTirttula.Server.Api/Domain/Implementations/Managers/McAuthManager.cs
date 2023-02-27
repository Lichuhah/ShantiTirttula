using ShantiTirttula.Server.Api.Domain.Interfaces.Managers;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;
using ShantiTirttula.Server.Api.Domain.Interfaces.Repositories;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Managers
{
    public class McAuthManager : EntityManager<IMcAuth>, IMcAuthManager
    {
        public McAuthManager(NHibernate.ISession session) : base(session)
        {

        }
    }
}
