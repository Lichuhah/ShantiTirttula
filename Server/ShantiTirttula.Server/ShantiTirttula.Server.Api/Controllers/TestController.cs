using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using ShantiTirttula.Server.Api.Domain.Helpers;
using ShantiTirttula.Server.Api.Domain.Implementations.Managers;
using ShantiTirttula.Server.Api.Domain.Implementations.Models;
using ShantiTirttula.Server.Api.Domain.Implementations.Repositories;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Controllers
{
    public class TestController : Controller
    {
        EntityManager<IEntity> man;
        public TestController()
        {
            NHibernateHelper helper = new NHibernateHelper();
            NHibernate.ISession session = helper.OpenSession();
            EntityRepository<IEntity> rep = new EntityRepository<IEntity>(session);
            man = new EntityManager<IEntity>(rep);
        }
        [HttpGet("all")]
        public string test()
        {
            
            var result = man.All();
            string answer = string.Empty;
            foreach(var item in result)
            {
                answer += "ID: " + item.Id + " Test: " + item.Test + "\n";
            }
            return answer;
        }

        [HttpDelete("del")]
        public string del(int id)
        {
            return man.Delete(man.Get(id)).ToString();
        }

        [HttpPost("post")]
        public string post([FromBody] Entity ent)
        {
            return man.Save(ent).ToString();
        }

    }
}
