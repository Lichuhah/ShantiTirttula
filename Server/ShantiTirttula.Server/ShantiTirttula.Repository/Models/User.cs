using ShantiTirttula.Domain.Models;

namespace ShantiTirttula.Repository.Models
{
    public class User : Entity, IUser
    {
        public virtual string Login { get; set; }
        public virtual string Password { get; set; }
    }
}
