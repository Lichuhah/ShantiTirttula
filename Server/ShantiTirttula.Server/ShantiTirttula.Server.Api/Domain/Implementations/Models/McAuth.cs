using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Models
{
    public class McAuth : Entity, IMcAuth
    {
        public virtual string Key { get; set; }
        public virtual IUser User { get; set; }
        public virtual IList<ITrigger> Triggers { get; set; }
        public virtual IMicroController Controller { get; set; }
    }
}
