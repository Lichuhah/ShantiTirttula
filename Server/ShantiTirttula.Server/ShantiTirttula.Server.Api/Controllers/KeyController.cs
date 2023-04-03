using Microsoft.AspNetCore.Mvc;

namespace ShantiTirttula.Server.Api.Controllers
{
    [Route("api/key")]
    public class KeyController : Controller
    {

        //[AllowAnonymous]
        //[HttpPost("get")]
        //public string GetNewKey([FromBody] McLoginData data)
        //{
        //    IUser user = CheckLogin(data);
        //    if (user != null)
        //    {
        //        return AddNewKey(data, user);
        //    }
        //    else
        //    {
        //        return "Errr";
        //    }

        //}
        //private IUser CheckLogin(McLoginData data)
        //{
        //    UserManager manager = new UserManager();
        //    return manager.CheckLogin(data.Login, data.Password);
        //}

        //private string AddNewKey(McLoginData data, IUser user)
        //{
        //    McAuthManager manager = new McAuthManager();
        //    MicroControllerManager controllerManager = new MicroControllerManager();
        //    string newkey = GenerateNewKey(manager);
        //    IMcAuth auth = new McAuth
        //    {
        //        Key = newkey,
        //        User = user,
        //        Controller = controllerManager.All().First(x => x.Mac == data.Mac)
        //    };
        //    manager.Save(auth);
        //    return newkey;
        //}

        //private string GenerateNewKey(McAuthManager manager)
        //{
        //    List<string> keys = manager.All().Select(x => x.Key).ToList();
        //    Random random = new Random(DateTime.UtcNow.Millisecond);
        //    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        //    while (true)
        //    {
        //        string res = new string(Enumerable.Repeat(chars, 16)
        //        .Select(s => s[random.Next(s.Length)]).ToArray());
        //        if (!keys.Contains(res)) return res;
        //    }
        //}

    }
}
