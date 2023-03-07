using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShantiTirttula.Server.Api.Controllers.Models;
using ShantiTirttula.Server.Api.Domain.Helpers;
using ShantiTirttula.Server.Api.Domain.Implementations.Managers;
using ShantiTirttula.Server.Api.Domain.Implementations.Models;
using ShantiTirttula.Server.Api.Domain.Implementations.Repositories;
using ShantiTirttula.Server.Api.Domain.Interfaces.Managers;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;
using System.Data.SqlClient;
using System.Drawing;
using System.Reflection.Emit;

namespace ShantiTirttula.Server.Api.Controllers
{
    [Route("api/key")]
    public class KeyController : BaseController
    {

        [AllowAnonymous]
        [HttpPost("get")]
        public string GetNewKey([FromBody] McLoginData data)
        {
            IUser user = CheckLogin(data);
            if(user != null)
            {
                return AddNewKey(data, user);            
            } else
            {
                return "Errr";
            }

        }
        private IUser CheckLogin(McLoginData data)
        {
            UserManager manager = new UserManager(Session);
            return manager.CheckLogin(data.Login, data.Password);
        }

        private string AddNewKey(McLoginData data, IUser user)
        {
            McAuthManager manager = new McAuthManager(Session);
            string newkey = GenerateNewKey(manager);
            McAuth auth = new McAuth
            {
                Mac = data.Mac,
                Key = newkey,
                User = user
            };
            manager.Save(auth);
            return newkey;
        }

        private string GenerateNewKey(McAuthManager manager)
        {
            List<string> keys = manager.All().Select(x=>x.Key).ToList();
            Random random = new Random(DateTime.UtcNow.Millisecond);
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            while (true)
            {
                string res = new string(Enumerable.Repeat(chars, 16)
                .Select(s => s[random.Next(s.Length)]).ToArray());
                if (!keys.Contains(res)) return res;
            }
        }
       
    }
}
