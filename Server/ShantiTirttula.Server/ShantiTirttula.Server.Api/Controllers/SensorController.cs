using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShantiTirttula.Server.Api.Controllers.Common;
using ShantiTirttula.Server.Api.Domain.Implementations.Managers;
using ShantiTirttula.Server.Api.Domain.Implementations.Models;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;
using ShantiTirttula.Server.Dispatcher.Models;
using System.Security.Claims;

namespace ShantiTirttula.Server.Api.Controllers
{
    [Route("api/sensor")]
    [ApiController]
    public class SensorController : Controller
    {
        //[Authorize]
        //[HttpPost("data/post")]
        //public string PostData([FromBody]List<McSensorData> listData)
        //{
        //    var b = HttpContext.User.Claims.ToList();
        //    var c = User.Claims;
        //    string serial = HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.SerialNumber).FirstOrDefault()?.Value;
        //    McAuthManager manager = new McAuthManager(Session);
        //    IMcAuth auth = manager.All().First(x => x.Key == serial);
        //    SensorManager manager2 = new SensorManager(Session);
        //    var listData2 = manager2.All().Where(x => x.Controller.Id == auth.Controller.Id);
        //    foreach (McSensorData data in listData)
        //    {
        //        ISensor sensor = listData2.FirstOrDefault(x => x.Number == data.SensorId);
        //        SensorDataManager sensorDataManager = new SensorDataManager(Session);
        //        sensorDataManager.Save(new SensorData
        //        {
        //            Id = 0,
        //            Sensor = sensor,
        //            Auth = auth,
        //            Value = data.Value
        //        });
        //        manager2.Save(sensor);
        //    }
        //    return "aa";
        //}     
     
    }
}
