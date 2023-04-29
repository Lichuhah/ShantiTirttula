using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShantiTirttula.Domain.Dto.Models;
using ShantiTirttula.Domain.Models;
using ShantiTirttula.Repository.Managers;
using ShantiTirttula.Server.Api.Controllers.Common;

namespace ShantiTirttula.Server.Api.Controllers.CrudControllers
{
    [Authorize]
    [Route("api/sensordata")]
    [ApiController]
    public class SensorDataController : BaseCrudController<SensorDataDto, ISensorData>
    {
        public SensorDataController() : base(new SensorDataManager())
        {

        }
    }
}
