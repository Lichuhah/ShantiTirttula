using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Controllers.Models.Dto
{
    public class SensorDto : ApiDto<ISensor>
    {
        public int ControllerId { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public int Number { get; set; }
    }
}
