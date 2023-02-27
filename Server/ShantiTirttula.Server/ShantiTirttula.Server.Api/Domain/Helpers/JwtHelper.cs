using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ShantiTirttula.Server.Api.Domain.Helpers
{
    public class JwtHelper
    {
        public const string ISSUER = "ShantiTirttulaServer";
        public const string AUDIENCE = "ShantiTirttulaClient";
        //public const int LIFETIME = 10;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("JWT_KEY")));
        }
    }
}
