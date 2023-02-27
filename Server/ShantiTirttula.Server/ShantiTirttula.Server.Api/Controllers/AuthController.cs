using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
    [Route("/api/auth")]
    public class AuthController : BaseController
    {
        [AllowAnonymous]
        [HttpPost("token")]
        public string GetToken(DispatcherLoginData data)
        {
            IMcAuth auth = CheckLogin(data);

            DateTime now = DateTime.UtcNow;

            JwtSecurityToken jwt = new JwtSecurityToken(
                    issuer: JwtHelper.ISSUER,
                    audience: JwtHelper.AUDIENCE,
                    notBefore: now,
                    claims: GetIdentity(auth).Claims,
                    signingCredentials: new SigningCredentials(JwtHelper.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }

        private IMcAuth CheckLogin(DispatcherLoginData data)
        {
            McAuthManager manager = new McAuthManager(Session);
            IMcAuth auth = manager.All().FirstOrDefault(x => x.Mac == data.Mac && x.Key == data.Key);
            return auth;
        }

        private ClaimsIdentity GetIdentity(IMcAuth auth)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, auth.Key)
                };
            ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }
    }
}
