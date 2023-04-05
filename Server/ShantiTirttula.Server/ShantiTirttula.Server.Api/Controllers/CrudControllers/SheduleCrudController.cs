using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShantiTirttula.Domain.Dto;
using ShantiTirttula.Domain.Dto.Models;
using ShantiTirttula.Domain.Models;
using ShantiTirttula.Domain.Models.Managment.Shedules;
using ShantiTirttula.Repository.Managers;
using ShantiTirttula.Repository.Managers.Managment.Shedules;
using ShantiTirttula.Server.Api.Controllers.Common;
using ShantiTirttula.Server.Api.Helpers.Quartz;

namespace ShantiTirttula.Server.Api.Controllers.CrudControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SheduleCrudController : BaseCrudController<SheduleDto, IShedule>
    {
        public SheduleCrudController() : base(new SheduleManager())
        {

        }

        [HttpPost]
        [Route("")]
        public override ActionResult Post([FromBody] SheduleDto dto)
        {
            try
            {
                IShedule data = Manager.ConvertFromDto(dto);
                dto.Id = Manager.Save(data).Id;
                QuartzShedulerHelper.NewShedule(Manager.Get(dto.Id));
                return new ApiResponse<SheduleDto>().SetData(dto).Result();
            }
            catch (Exception e)
            {
                return new ApiResponse<object>().Error(e.Message).Result();
            }
        }
    }
}
