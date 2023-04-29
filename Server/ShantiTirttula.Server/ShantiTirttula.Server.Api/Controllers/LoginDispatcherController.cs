using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ShantiTirttula.Domain.Dto;
using ShantiTirttula.Domain.Dto.Input;
using ShantiTirttula.Domain.Models;
using ShantiTirttula.Repository.Managers;
using ShantiTirttula.Server.Api.Helpers;
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
                IAuth auth = CheckLogin(loginData);
                return new ApiResponse<string>().SetData(GenerateJwt(auth)).Result();
            }
            catch (Exception e)
            {
                return new ApiResponse<object>().Error(e.Message).Result();
            }
        }

        private IAuth CheckLogin(DispAuthDtoInput data)
        {
            try
            {
                AuthManager manager = new AuthManager();
                IAuth auth = manager.All().FirstOrDefault(x => x.Product.Mac == data.Mac && x.Key == data.Key);
                return auth;
            }
            catch (Exception ex) { throw; }
        }

        private string GenerateJwt(IAuth auth)
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
