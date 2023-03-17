using ShantiTirttula.Server.Api.Domain.Interfaces.Managers;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Managers
{
    public class MicroControllerTypeManager : EntityManager<IMicroControllerType>, IMicroControllerTypeManager
    {
        public MicroControllerTypeManager() : base()
        {

        }
    }
}
