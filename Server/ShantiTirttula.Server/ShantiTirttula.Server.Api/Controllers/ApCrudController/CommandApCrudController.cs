using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShantiTirttula.Domain.Dto.Models;
using ShantiTirttula.Domain.Models.Managment.Shedules;
using ShantiTirttula.Repository.Managers.Managment.Shedules;
using ShantiTirttula.Server.Api.Controllers.Common;

namespace ShantiTirttula.Server.Api.Controllers.ApCrudController
{
    [Authorize]
    [Route("api/ap/commands")]
    [ApiController]
    public class CommandApCrudController : BaseApCrudController<CommandDto, ISheduleCommand>
    {
        public CommandApCrudController(IHttpContextAccessor httpContextAccessor) : base(new SheduleCommandManager(), httpContextAccessor)
        {

        }
    }
}
