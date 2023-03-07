using ShantiTirttula.Server.Api.Domain.Interfaces.Managers;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Managers
{
    public class DeviceManager : EntityManager<IDevice>, IDeviceManager
    {
        public DeviceManager(NHibernate.ISession session) : base(session)
        {

        }
    }
}
