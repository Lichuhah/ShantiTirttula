using ShantiTirttula.Domain.Models;

namespace ShantiTirttula.Repository.Models
{
    public class CommandLog : Entity, ICommandLog
    {
        public virtual IAuth Auth { get; set; }
        public virtual ITrigger Trigger { get; set; }
        public virtual DateTime DateTime { get; set; }
    }
}
