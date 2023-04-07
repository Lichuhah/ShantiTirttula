using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShantiTirttula.Server.Dispatcher.Sessions;

namespace ShantiTirttula.Server.Dispatcher.Controllers
{
    [Route("api/disp")]
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
    }
}
