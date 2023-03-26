using ApiModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ShantiTirttula.Server.Api.Controllers.Models.Input;
using ShantiTirttula.Server.Api.Domain.Helpers;
using ShantiTirttula.Server.Api.Domain.Implementations.Managers;
using ShantiTirttula.Server.Api.Domain.Implementations.Models;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ShantiTirttula.Server.Api.Controllers
{
    [Route("api/disp")]
    [ApiController]
    public class LoginDispatcherController : ControllerBase
    {

        [AllowAnonymous]
        [HttpPost]
        [Route("signin")]
        public ActionResult LoginUser([FromBody] DispAuthDtoInput loginData)
        {
            try
            {
                IMcAuth auth = CheckLogin(loginData);
                return new ApiResponse<string>().SetData(GenerateJwt(auth)).Result();
            }
            catch (Exception e)
            {
                return new ApiResponse<object>().Error(e.Message).Result();
            }
        }

        private IMcAuth CheckLogin(DispAuthDtoInput data)
        {
            try
            {
                McAuthManager manager = new McAuthManager();
                IMcAuth auth = manager.All().FirstOrDefault(x => x.Controller.Mac == data.Mac && x.Key == data.Key);
                return auth;
            }
            catch (Exception ex) { throw; }
        }

        private string GenerateJwt(IMcAuth auth)
        {
            DateTime now = DateTime.UtcNow;

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Sid, auth.Id.ToString()),
                    new Claim(ClaimTypes.Name, auth.Key),
                    new Claim(ClaimTypes.Actor, "MC")
                };

            JwtSecurityToken jwt = new JwtSecurityToken(
                    issuer: JwtHelper.ISSUER,
                    audience: JwtHelper.AUDIENCE,
                    notBefore: now,
                    claims: claims,
                    signingCredentials: new SigningCredentials(JwtHelper.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            string encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }
    }
}
