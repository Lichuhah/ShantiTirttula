using Microsoft.AspNetCore.Mvc;
using ShantiTirttula.Server.Api.Domain.Helpers;

namespace ShantiTirttula.Server.Api.Controllers
{
    public class BaseController : Controller
    {
        protected readonly NHibernate.ISession Session;
        public BaseController()
        {
            NHibernateHelper helper = new NHibernateHelper();
            Session = helper.OpenSession();
        }
    }
}
