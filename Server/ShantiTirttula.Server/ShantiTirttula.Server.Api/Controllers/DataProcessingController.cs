using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShantiTirttula.Domain.Dto;
using ShantiTirttula.Domain.Dto.Models;
using ShantiTirttula.Domain.Models;
using ShantiTirttula.Repository.Helpers;
using ShantiTirttula.Repository.Managers;

namespace ShantiTirttula.Server.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/test/data-proc")]
    [ApiController]
    public class DataProcessingController : ControllerBase
    {
        [HttpGet("{id:int}")]
        public ActionResult get(int id)
        {
            SensorManager sensorManager = new SensorManager();
            ISensor sensor = sensorManager.Get(id);
            var dto = sensor.SensorDatas.Select(x => new SensorDataDto()
            {
                Id = x.Id,
                DateTime = x.DateTime,
                Value = SensorAlgorithmHelper.GetValue(x)
            }).ToList();
            return new ApiResponse<List<SensorDataDto>>().SetData(dto).Result();
        }
        
        [HttpGet("{id:int}/bytime/{start:datetime}/{end:datetime}")]
        public ActionResult GetByTime(int id, DateTime start, DateTime end)
        {
            SensorManager sensorManager = new SensorManager();
            ISensor sensor = sensorManager.Get(id);
            var data = sensor.SensorDatas.Where(x => x.DateTime > start && x.DateTime < end);
            var dto = data.Select(x => new SensorDataDto()
            {
                Id = x.Id,
                DateTime = x.DateTime,
                Value = SensorAlgorithmHelper.GetValue(x)
            }).ToList();
            return new ApiResponse<List<SensorDataDto>>().SetData(dto).Result();
        }

    }
}
