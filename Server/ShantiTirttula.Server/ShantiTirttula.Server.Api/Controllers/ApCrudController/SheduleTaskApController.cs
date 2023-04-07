using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShantiTirttula.Domain.Dto;
using ShantiTirttula.Domain.Dto.Models;
using ShantiTirttula.Domain.Models;
using ShantiTirttula.Domain.Models.Managment.Shedules;
using ShantiTirttula.Repository.Managers;
using ShantiTirttula.Repository.Managers.Managment.Shedules;
using ShantiTirttula.Server.Api.Controllers.Common;

namespace ShantiTirttula.Server.Api.Controllers.ApCrudController
{
    [Authorize]
    [Route("api/ap/shedule-task")]
    [ApiController]
    public class SheduleTaskApController : BaseApCrudController<SheduleTaskDto, ISheduleTask>
    {
        public SheduleTaskApController(IHttpContextAccessor httpContextAccessor) : base(new SheduleTaskManager(), httpContextAccessor)
        {

        }
    }
}
