using ShantiTirttula.Domain.Managers;
using ShantiTirttula.Domain.Models;

namespace ShantiTirttula.Repository.Managers
{
    public class DeviceTypeManager : EntityManager<IDeviceType>, IDeviceTypeManager
    {
        public DeviceTypeManager() : base()
        {

        }
    }
}
