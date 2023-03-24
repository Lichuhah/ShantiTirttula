using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShantiTirttula.Server.Api.Controllers.Common;
using ShantiTirttula.Server.Api.Controllers.Models.Dto;
using ShantiTirttula.Server.Api.Domain.Implementations.Managers;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Controllers.CrudControllers
{
    [Authorize]
    [Route("api/triggers")]
    [ApiController]
    public class TriggerCrudController : BaseUserCrudController<TriggerDto, ITrigger>
    {
        public TriggerCrudController(IHttpContextAccessor httpContextAccessor) : base(new TriggerManager(), httpContextAccessor)
        {

        }
    }
}
