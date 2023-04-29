using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShantiTirttula.Domain.Dto.Models;
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
        [Route("prod-data/{key}")]
        public string GetProdData(string key)
        {
            Session session = SessionList.GetList().Sessions.FirstOrDefault(ses => ses.Mc.Key == key);
            if (session != null)
            {
                return session.Producer.GetData();
            }
            else return string.Empty;
        }

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

        [HttpGet]
        [Route("clear")]
        public bool ClearSessions()
        {
            SessionList.GetList().Sessions.Clear();
            return true;
        }

        [HttpPost]
        [Route("cf/{key}")]
        public bool NewConfig(string key, [FromBody] List<TriggerDto> config)
        {
            try
            {
                Session session = SessionList.GetList().Sessions.FirstOrDefault(ses => ses.Mc.Key == key);
                if (session != null)
                {
                    ShantiMqttServer mqttServer = ShantiMqttServer.GetServer();
                    mqttServer.SendMessage(session.Mc.Key + "_f", JsonConvert.SerializeObject(config));
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
