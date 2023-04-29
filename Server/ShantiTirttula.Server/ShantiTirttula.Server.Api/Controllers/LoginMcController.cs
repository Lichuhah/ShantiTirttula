using Microsoft.AspNetCore.Mvc;
using ShantiTirttula.Domain.Dto;
using ShantiTirttula.Domain.Dto.Input;
using ShantiTirttula.Domain.Models;
using ShantiTirttula.Repository.Managers;
using ShantiTirttula.Repository.Models;

namespace ShantiTirttula.Server.Api.Controllers
{
    [Route("api/mc")]
    [ApiController]
    public class LoginMcController : ControllerBase
    {
        [HttpPost]
        [Route("signup")]
        public ActionResult RegisterMc([FromBody] McAuthDtoInput authData)
        {
            try
            {
                UserManager manager = new UserManager();
                IQueryable<IUser> users = manager.All().Where(x => x.Login == authData.Login && x.Password == authData.Password);
                if (users.Any())
                {
                    return new ApiResponse<string>().SetData(AddNewKey(authData, users.First())).Result();
                }
                else
                {
                    return new ApiResponse<object>().Error("Wrong user data").Result();
                }
            }
            catch (Exception e)
            {
                return new ApiResponse<object>().Error(e.Message).Result();
            }
        }

        private string AddNewKey(McAuthDtoInput data, IUser user)
        {
            AuthManager manager = new AuthManager();
            ProductManager productManager = new ProductManager();
            string newkey = GenerateNewKey(manager);

            data.Mac = data.Mac.Replace(":", "");
            IAuth auth = new Auth
            {
                Key = newkey,
                User = user,
                Product = productManager.All().First(x => x.Mac == data.Mac)
            };
            manager.Save(auth);
            return newkey;
        }

        private string GenerateNewKey(AuthManager manager)
        {
            List<string> keys = manager.All().Select(x => x.Key).ToList();
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
