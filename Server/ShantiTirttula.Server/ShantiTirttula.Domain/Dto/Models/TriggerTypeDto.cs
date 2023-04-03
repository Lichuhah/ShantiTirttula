using ShantiTirttula.Domain.Models;

namespace ShantiTirttula.Domain.Dto.Models
{
    public class TriggerTypeDto : ApiDto<ITriggerType>
    {
        public string Name { get; set; }
    }
}
