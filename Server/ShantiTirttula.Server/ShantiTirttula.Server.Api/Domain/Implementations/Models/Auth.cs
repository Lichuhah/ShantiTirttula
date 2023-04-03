using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Models
{
    public class Auth : Entity, IAuth
    {
        public virtual string Key { get; set; }
        public virtual IUser User { get; set; }
        public virtual IList<ITrigger> Triggers { get; set; }
        public virtual IProduct Product { get; set; }
    }
}
