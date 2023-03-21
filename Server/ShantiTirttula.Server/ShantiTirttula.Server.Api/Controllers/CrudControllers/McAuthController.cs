using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShantiTirttula.Server.Api.Controllers.Common;
using ShantiTirttula.Server.Api.Controllers.Models.Dto;
using ShantiTirttula.Server.Api.Domain.Implementations.Managers;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Controllers.CrudControllers
{
    [Authorize]
    [Route("api/mcauth")]
    [ApiController]
    public class McAuthController : BaseUserCrudController<McAuthDto, IMcAuth>
    {
        public McAuthController(IHttpContextAccessor httpContextAccessor) : base(new McAuthManager(), httpContextAccessor)
        {

        }
    }
}
