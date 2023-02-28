using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShantiTirttula.Server.Api.Domain.Implementations.Managers;
using ShantiTirttula.Server.Api.Domain.Implementations.Models;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;
using ShantiTirttula.Server.Dispatcher.Models;
using System.Security.Claims;

namespace ShantiTirttula.Server.Api.Controllers
{
    [Route("api/sensor")]
    [ApiController]
    public class SensorController : BaseController
    {
        [Authorize]
        [HttpPost("data/post")]
        public string PostData([FromBody]List<McSensorData> listData)
        {
            var b = HttpContext.User.Claims.ToList();
            var c = User.Claims;
            string serial = HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.SerialNumber).FirstOrDefault()?.Value;
            McAuthManager manager = new McAuthManager(Session);
            IMcAuth auth = manager.All().First(x => x.Key == serial);
            SensorManager manager2 = new SensorManager(Session);
            var listData2 = manager2.All().Where(x => x.Auth.Id == auth.Id);
            var listData3 = listData2.ToList();
            foreach (McSensorData data in listData)
            {
                ISensor sensor = listData2.FirstOrDefault(x => x.Number == data.SensorId);
                sensor.SensorDatas.Add(new SensorData
                {
                    Value = data.Value,
                    DateTime = DateTime.UtcNow
                });
                manager2.Save(sensor);
            }
            return "aa";
        }

        [AllowAnonymous]
        [HttpGet("test")]
        public void aa()
        {
            SensorManager manager2 = new SensorManager(Session);
            var list = manager2.All().ToList();
            var c = "f";
        }
     
    }
}
