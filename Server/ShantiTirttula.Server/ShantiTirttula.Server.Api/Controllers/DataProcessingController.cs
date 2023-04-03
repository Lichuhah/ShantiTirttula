using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        public string get(int id)
        {
            SensorManager sensorManager = new SensorManager();
            ISensor sensor = sensorManager.Get(id);
            var algorithm = sensor.Type.Algorithm;
            var result = sensor.SensorDatas.Select(x => SensorAlgorithmHelper.GetValue(x)).ToList();
            return JsonConvert.SerializeObject(result);
        }
    }
}
