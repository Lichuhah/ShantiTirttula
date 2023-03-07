using ShantiTirttula.Server.Api.Domain.Interfaces.Managers;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Managers
{
    public class DeviceLogManager : EntityManager<IDeviceLog>, IDeviceLogManager
    {
        public DeviceLogManager(NHibernate.ISession session) : base(session)
        {

        }
    }
}
