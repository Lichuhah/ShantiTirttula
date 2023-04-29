using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShantiTirttula.Domain.Dto.Models;
using ShantiTirttula.Domain.Models;
using ShantiTirttula.Repository.Managers;
using ShantiTirttula.Server.Api.Controllers.Common;

namespace ShantiTirttula.Server.Api.Controllers.ApCrudController
{

    [Authorize]
    [Route("api/ap/sensor")]
    [ApiController]
    public class SensorApCrudController : BaseApCrudController<SensorDto, ISensor>
    {
        public SensorApCrudController(IHttpContextAccessor httpContextAccessor) : base(new SensorManager(), httpContextAccessor)
        {

        }
    }
}
