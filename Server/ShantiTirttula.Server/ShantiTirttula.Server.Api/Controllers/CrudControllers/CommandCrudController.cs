using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShantiTirttula.Domain.Dto.Models;
using ShantiTirttula.Domain.Models.Managment.Shedules;
using ShantiTirttula.Repository.Managers.Managment.Shedules;
using ShantiTirttula.Server.Api.Controllers.Common;

namespace ShantiTirttula.Server.Api.Controllers.CrudControllers
{
    [Authorize]
    [Route("api/commands")]
    [ApiController]
    public class CommandCrudController : BaseCrudController<CommandDto, ISheduleCommand>
    {
        public CommandCrudController() : base(new SheduleCommandManager())
        {

        }
    }
}
