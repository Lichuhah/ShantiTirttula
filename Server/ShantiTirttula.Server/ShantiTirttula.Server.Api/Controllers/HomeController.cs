using Microsoft.AspNetCore.Mvc;

namespace ShantiTirttula.Server.Api.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
