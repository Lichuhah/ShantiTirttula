using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShantiTirttula.Server.Api.Domain.Implementations.Managers;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;
using ShantiTirttula.Server.Api.Controllers.Common;
using ShantiTirttula.Server.Api.Controllers.Models.Dto;

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
