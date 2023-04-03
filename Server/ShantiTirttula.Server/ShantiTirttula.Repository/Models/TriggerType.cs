using ShantiTirttula.Domain.Models;

namespace ShantiTirttula.Repository.Models
{
    public class TriggerType : Entity, ITriggerType
    {
        public virtual string Name { get; set; }
    }
}
