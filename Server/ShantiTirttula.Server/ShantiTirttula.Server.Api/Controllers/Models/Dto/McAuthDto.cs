using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Controllers.Models.Dto
{
    public class McAuthDto : ApiDto<IMcAuth>
    {
        public int ControllerId { get; set; }
        public string Key { get; set; }
        public string Mac { get; set; }
        public string TypeName { get; set; }
    }
}
