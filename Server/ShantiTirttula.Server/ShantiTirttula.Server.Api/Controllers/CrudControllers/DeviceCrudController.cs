using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShantiTirttula.Server.Api.Controllers.Common;
using ShantiTirttula.Domain.Models;
using ShantiTirttula.Repository.Managers;
using ShantiTirttula.Domain.Dto.Models;

namespace ShantiTirttula.Server.Api.Controllers.CrudControllers
{
    [Authorize]
    [Route("api/devices")]
    [ApiController]
    public class DeviceCrudController : BaseCrudController<DeviceDto, IDevice>
    {
        public DeviceCrudController() : base(new DeviceManager())
        {

        }
    }
}
