using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShantiTirttula.Server.Api.Controllers.Common;
using System.Text;
using Newtonsoft.Json;
using ShantiTirttula.Repository.Managers;
using ShantiTirttula.Domain.Dto;
using ShantiTirttula.Domain.Models;
using ShantiTirttula.Domain.Dto.Models;

namespace ShantiTirttula.Server.Api.Controllers.CrudControllers
{
    [Authorize]
    [Route("api/triggers")]
    [ApiController]
    public class TriggerCrudController : BaseUserCrudController<TriggerDto, ITrigger>
    {
        public TriggerCrudController(IHttpContextAccessor httpContextAccessor) : base(new TriggerManager(), httpContextAccessor)
        {

        }   
    }
}
