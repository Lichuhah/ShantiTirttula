using ShantiTirttula.Domain.Models;

namespace ShantiTirttula.Domain.Dto.Models
{
    public class UserDto : ApiDto<IUser>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
