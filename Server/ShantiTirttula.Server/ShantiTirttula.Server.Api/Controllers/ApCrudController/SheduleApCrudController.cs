using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShantiTirttula.Domain.Dto.Models;
using ShantiTirttula.Domain.Models.Managment.Shedules;
using ShantiTirttula.Repository.Managers.Managment.Shedules;
using ShantiTirttula.Server.Api.Controllers.Common;

namespace ShantiTirttula.Server.Api.Controllers.ApCrudController
{

    [Authorize]
    [Route("api/ap/shedules")]
    [ApiController]
    public class SheduleApCrudController : BaseApCrudController<SheduleDto, IShedule>
    {
        public SheduleApCrudController(IHttpContextAccessor httpContextAccessor) : base(new SheduleManager(), httpContextAccessor)
        {

        }
    }
}
