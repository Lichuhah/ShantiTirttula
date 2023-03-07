using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Models
{
    public class TriggerType : Entity, ITriggerType
    {
        public virtual string Name { get; set; }
    }
}
