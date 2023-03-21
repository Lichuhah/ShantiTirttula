using ApiModels;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Type;
using ShantiTirttula.Server.Api.Controllers.Models;
using ShantiTirttula.Server.Api.Controllers.Models.Dto;
using System.Xml.Linq;
using ShantiTirttula.Server.Api.Controllers.CrudControllers;
using ShantiTirttula.Server.Api.Domain.Implementations.Managers;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;
using System.Data;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using ShantiTirttula.Server.Api.Domain.Helpers;
using Microsoft.IdentityModel.Tokens;

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
                    return new ApiResponse<string>().SetData(GenerateJwt(users.First())).Result();
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
