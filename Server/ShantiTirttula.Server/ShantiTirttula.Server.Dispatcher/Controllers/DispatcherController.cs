using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShantiTirttula.Domain.Dto.Output;
using ShantiTirttula.Server.Dispatcher.Mqtt;
using ShantiTirttula.Server.Dispatcher.Sessions;

namespace ShantiTirttula.Server.Dispatcher.Controllers
{
    [Route("api/disp")]
    [AllowAnonymous]
    [ApiController]
    public class DispatcherController : ControllerBase
    {
        [HttpGet]
        [Route("{key}")]
        public bool RefreshSession(string key)
        {
            try
            {
                Session session = SessionList.GetList().Sessions.FirstOrDefault(ses => ses.Mc.Key == key);
                if (session != null)
                {
                    session.IsBusy = true;
                    SessionList.RefreshSession(session);
                    session.IsBusy = false;
                }
                else
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("cf/{key}")]
        public bool NewConfig(string key, [FromBody] List<TriggerOutput> config)
        {
            try
            {
                Session session = SessionList.GetList().Sessions.FirstOrDefault(ses => ses.Mc.Key == key);
                if (session != null)
                {
                    ShantiMqttServer mqttServer = ShantiMqttServer.GetServer();
                    mqttServer.SendMessage(session.Mc.Key+ "_cf", JsonConvert.SerializeObject(config));
                }
                else
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
