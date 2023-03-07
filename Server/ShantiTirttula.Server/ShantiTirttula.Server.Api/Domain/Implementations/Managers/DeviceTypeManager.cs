using ShantiTirttula.Server.Api.Domain.Interfaces.Managers;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Managers
{
    public class DeviceTypeManager : EntityManager<IDeviceType>, IDeviceTypeManager
    {
        public DeviceTypeManager(NHibernate.ISession session) : base(session)
        {

        }
    }
}
