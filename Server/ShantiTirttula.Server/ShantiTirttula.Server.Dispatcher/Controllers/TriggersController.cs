using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShantiTirttula.Server.Dispatcher.Models;
using ShantiTirttula.Server.Dispatcher.Sessions;

namespace ShantiTirttula.Server.Dispatcher.Controllers
{
    [Route("api/triggers")]
    [ApiController]
    public class TriggersController : ControllerBase
    {
        [HttpPost]
        [Route("{key}")]
        public bool NewTriggers(string key, [FromBody] List<DispatcherTrigger> triggers)
        {
            try
            {
                Session session = SessionList.GetList().Sessions.FirstOrDefault(ses => ses.Mc.Key == key);
                if (session != null)
                {
                    session.IsBusy = true;
                    session.Triggers.Clear();
                    session.Triggers = triggers;
                    session.IsBusy = false;
                }
                else
                    return false;
                return true;
            } catch (Exception ex)
            {
                return false;
            }
        }
    }
}
