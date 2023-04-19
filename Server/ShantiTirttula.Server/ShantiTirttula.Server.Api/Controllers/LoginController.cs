using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using ShantiTirttula.Domain.Models;
using ShantiTirttula.Domain.Dto;
using ShantiTirttula.Server.Api.Helpers;
using ShantiTirttula.Domain.Dto.Models;
using ShantiTirttula.Repository.Managers;
using static DevExpress.Data.Helpers.FindSearchRichParser;

namespace ShantiTirttula.Server.Api.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        [Route("signin")]
        public ActionResult LoginUser([FromBody] UserDto loginData)
        {
            try
            {
                UserManager manager = new UserManager();
                IQueryable<IUser> users = manager.All().Where(x=>x.Login == loginData.Login && x.Password == loginData.Password);
                if(users.Any())
                {
                    HttpContext.Session.SetInt32("UserId", users.First().Id);

                    string token = GenerateJwt(users.First());

                    HttpContext.Response.Cookies.Append(".ShantiTirttula.User.Token", token,
                        new CookieOptions { MaxAge = TimeSpan.FromMinutes(300) });

                    return new ApiResponse<bool>().SetData(true).Result();
                } else
                {
                    return new ApiResponse<object>().Error("Wrong user data").Result();
                }                
            }
            catch (Exception e)
            {
                return new ApiResponse<object>().Error(e.Message).Result();
            }
        }

        [Authorize]
        [HttpGet]
        [Route("check")]
        public ActionResult CheckLogin()
        {
            return new ApiResponse<bool>().SetData(true).Result();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("signup")]
        public ActionResult RegisterUser([FromBody] UserDto loginData)
        {
            try
            {
                UserManager manager = new UserManager();
                IQueryable<IUser> users = manager.All().Where(x => x.Login == loginData.Login);
                if (users.Any())
                {
                    return new ApiResponse<object>().Error("This user already exist").Result();
                }
                else
                {
                    IUser newUser = manager.Save(manager.ConvertFromDto(loginData));
                    return new ApiResponse<bool>().SetData(true).Result();
                }
            }
            catch (Exception e)
            {
                return new ApiResponse<object>().Error(e.Message).Result();
            }
        }

        private string GenerateJwt(IUser user)
        {
            DateTime now = DateTime.UtcNow;

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Sid, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Login)
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
