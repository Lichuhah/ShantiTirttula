using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Controllers.Models.Dto
{
    public class DeviceDto : ApiDto<IDevice>
    {
        public int ControllerId { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public int Pin { get; set; }
        public bool IsPwm { get; set; }
    }
}
