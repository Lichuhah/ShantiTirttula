using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using ShantiTirttula.Server.Api.Controllers.Common;
using ShantiTirttula.Server.Api.Controllers.Models.Dto;
using ShantiTirttula.Server.Api.Domain.Implementations.Managers;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Controllers.CrudControllers
{
    [AllowAnonymous]
    [Microsoft.AspNetCore.Mvc.Route("api/users")]
    [ApiController]
    public class UserCrudController : BaseCrudController<UserDto, IUser>
    {
        public UserCrudController() : base(new UserManager())
        {
        }
    }
}
