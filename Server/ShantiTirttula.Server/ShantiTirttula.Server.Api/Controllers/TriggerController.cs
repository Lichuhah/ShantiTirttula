using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShantiTirttula.Server.Api.Controllers.Models.Output;
using ShantiTirttula.Server.Api.Domain.Implementations.Managers;
using ShantiTirttula.Server.Api.Domain.Implementations.Models;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;
using ShantiTirttula.Server.Dispatcher.Models;
using System.Security.Claims;

namespace ShantiTirttula.Server.Api.Controllers
{
    [Route("api/trigger")]
    [ApiController]
    public class TriggerController : BaseController
    {
        [Authorize]
        [HttpGet("list")]
        public string GetTriggers()
        {
            var b = HttpContext.User.Claims.ToList();
            var c = User.Claims;
            string serial = HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.SerialNumber).FirstOrDefault()?.Value;
            McAuthManager manager = new McAuthManager(Session);
            IMcAuth auth = manager.All().First(x => x.Key == serial);
            List<TriggerOutput> output = new List<TriggerOutput>();
            foreach(ITrigger trigger in auth.Triggers)
            {
                output.Add(new TriggerOutput()
                {
                    Type = trigger.Type.Id,
                    SensorNumber = trigger.Sensor.Number,
                    TriggerValue = trigger.TriggerValue,
                    DeviceValue = trigger.DeviceValue,
                    Pin = trigger.Device.Pin,
                    IsPwm = trigger.Device.IsAnalog
                });
            }
            return JsonConvert.SerializeObject(output);
        }
    }
}
