using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using ShantiTirttula.Server.Api.Domain.Helpers;
using ShantiTirttula.Server.Api.Domain.Implementations.Managers;
using ShantiTirttula.Server.Api.Domain.Implementations.Repositories;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Controllers
{
    public class TestController : Controller
    {
        [HttpGet("test")]
        public string test()
        {
            NHibernateHelper helper = new NHibernateHelper();
            NHibernate.ISession session = helper.OpenSession();
            EntityRepository<IEntity> rep = new EntityRepository<IEntity>(session);
            EntityManager<IEntity> man = new EntityManager<IEntity>(rep);
            var result = man.All();
            return result.ToList().Count.ToString();
        }
        
    }
}
