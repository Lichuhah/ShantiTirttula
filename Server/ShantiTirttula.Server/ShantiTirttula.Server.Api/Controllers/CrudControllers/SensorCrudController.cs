using ShantiTirttula.Domain.Models;
using ShantiTirttula.Repository.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShantiTirttula.Server.Api.Controllers.Common;
using ShantiTirttula.Domain.Dto.Models;

namespace ShantiTirttula.Server.Api.Controllers.CrudControllers
{
    [Authorize]
    [Route("api/sensors")]
    [ApiController]
    public class SensorCrudController : BaseCrudController<SensorDto, ISensor>
    {
        public SensorCrudController() : base(new SensorManager())
        {

        }
    }
}
