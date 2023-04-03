using ShantiTirttula.Domain.Managers;
using ShantiTirttula.Domain.Models;

namespace ShantiTirttula.Repository.Managers
{
    public class MicroControllerManager : EntityManager<IMicroController>, IMicroControllerManager
    {
        public MicroControllerManager() : base()
        {

        }
    }
}
