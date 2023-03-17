using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ShantiTirttula.Server.Api.Controllers.Common;
using ShantiTirttula.Server.Api.Controllers.Models;
using ShantiTirttula.Server.Api.Domain.Enums;
using ShantiTirttula.Server.Api.Domain.Helpers;
using ShantiTirttula.Server.Api.Domain.Implementations.Managers;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ShantiTirttula.Server.Api.Controllers
{
    [Route("api/auth")]
    public class AuthController : Controller
    {
        //[AllowAnonymous]
        //[HttpPost("token")]
        //public string GetToken([FromBody] DispatcherLoginData data)
        //{
        //    IMcAuth auth = CheckLogin(data);

        //    DateTime now = DateTime.UtcNow;

        //    var claims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.SerialNumber, auth.Key)
        //    };
        //    HttpContext.User.Claims.Append(new Claim(ClaimTypes.SerialNumber, auth.Key));
        //    JwtSecurityToken jwt = new JwtSecurityToken(
        //            issuer: JwtHelper.ISSUER,
        //            audience: JwtHelper.AUDIENCE,
        //            notBefore: now,
        //            claims: claims,
        //            signingCredentials: new SigningCredentials(JwtHelper.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
        //    var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        //    return encodedJwt;
        //}

        //[AllowAnonymous]
        //[HttpGet("test")]
        //public string Get()
        //{
        //    UserManager manager = new UserManager();
        //    return manager.Get(1).Login;
        //}

        //private IMcAuth CheckLogin(DispatcherLoginData data)
        //{
        //    McAuthManager manager = new McAuthManager();
        //    IMcAuth auth = manager.All().FirstOrDefault(x => x.Controller.Mac == data.Mac && x.Key == data.Key);
        //    return auth;
        //}
    }
}
