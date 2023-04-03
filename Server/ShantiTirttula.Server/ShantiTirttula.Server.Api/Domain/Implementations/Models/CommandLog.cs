using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Models
{ 
    public class CommandLog : Entity, ICommandLog
    {
        public virtual IAuth Auth { get; set; }
        public virtual ITrigger Trigger { get; set; }
        public virtual DateTime DateTime { get; set; }
    }
}
