using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Models
{
    public class User : Entity, IUser
    {
        public virtual string Login { get; set; }
        public virtual string Password { get; set; }
    }
}
