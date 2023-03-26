using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Controllers.Models.Dto
{
    public class TriggerTypeDto : ApiDto<ITriggerType>
    {
        public string Name { get; set; }
    }
}
