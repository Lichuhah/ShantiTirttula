using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using ShantiTirttula.Server.Api.Controllers.Common;
using ShantiTirttula.Server.Api.Controllers.Models.Dto;
using ShantiTirttula.Server.Api.Domain.Implementations.Managers;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Controllers.CrudControllers
{
    [AllowAnonymous]
    [Route("api/users")]
    public class UserCrudController : BaseCrudController<UserDto, IUser>
    {
        public UserCrudController() : base(new UserManager())
        {
        }
    }
}
