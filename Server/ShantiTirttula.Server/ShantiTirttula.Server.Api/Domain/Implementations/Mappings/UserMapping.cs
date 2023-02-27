using ShantiTirttula.Server.Api.Domain.Implementations.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Mappings
{
    public class UserMapping : EntityMapping<User>
    {
        public UserMapping() : base("SYS_USER")
        {
            Property(x => x.Login, map =>
            {
                map.Column("LOGIN");
            });
            Property(x => x.Password, map =>
            {
                map.Column("PASSWORD");
            });
        }
    }
}
