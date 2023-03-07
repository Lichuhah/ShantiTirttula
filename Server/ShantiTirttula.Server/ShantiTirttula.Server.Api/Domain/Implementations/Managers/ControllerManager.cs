using ShantiTirttula.Server.Api.Domain.Interfaces.Managers;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Managers
{
    public class ControllerManager : EntityManager<IController>, IControllerManager
    {
        public ControllerManager(NHibernate.ISession session) : base(session)
        {

        }
    }
}
