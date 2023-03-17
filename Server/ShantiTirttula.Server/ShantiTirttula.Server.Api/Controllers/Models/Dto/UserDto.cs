using ShantiTirttula.Server.Api.Domain.Implementations.Models;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Controllers.Models.Dto
{
    public class UserDto : ApiDto<IUser>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
