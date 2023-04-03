using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShantiTirttula.Domain.Models;
using ShantiTirttula.Server.Api.Controllers.Common;
using ShantiTirttula.Domain.Dto.Models;
using ShantiTirttula.Repository.Managers;

namespace ShantiTirttula.Server.Api.Controllers.CrudControllers
{
    [AllowAnonymous]
    [Route("api/users")]
    [ApiController]
    public class UserCrudController : BaseCrudController<UserDto, IUser>
    {
        public UserCrudController() : base(new UserManager())
        {
        }
    }
}
