using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShantiTirttula.Server.Dispatcher.Models;
using ShantiTirttula.Server.Dispatcher.Sessions;

namespace ShantiTirttula.Server.Dispatcher.Controllers
{
    [Route("api/triggers")]
    [ApiController]
    public class TriggersController : ControllerBase
    {
        //[HttpGet]
        //public string GetTriggers()
        //{
        //    return JsonConvert.SerializeObject(SessionList.GetList().Sessions.First());
        //}

        //[HttpPost]
        //[Route("{key}")]
        //public bool NewTriggers(string key, [FromBody] List<DispatcherTrigger> triggers)
        //{
        //    try
        //    {
        //        Session session = SessionList.GetList().Sessions.FirstOrDefault(ses => ses.Mc.Key == key);
        //        if (session != null)
        //        {
        //            session.IsBusy = true;
        //            session.Triggers.Clear();
        //            session.Triggers = triggers;
        //            session.IsBusy = false;
        //        }
        //        else
        //            return false;
        //        return true;
        //    } catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}
    }
}
