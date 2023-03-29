using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShantiTirttula.Server.Api.Domain.Implementations.Managers;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;
using ShantiTirttula.Server.Api.Controllers.Common;
using ShantiTirttula.Server.Api.Controllers.Models.Dto;

namespace ShantiTirttula.Server.Api.Controllers.CrudControllers
{

    [Authorize]
    [Route("api/commandlog")]
    [ApiController]
    public class CommandLogController : BaseMcCrudController<CommandLogDto, ICommandLog>
    {
        public CommandLogController(IHttpContextAccessor accessor) : base(new CommandLogManager(), accessor)
        {

        }
    }
}
