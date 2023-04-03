using ShantiTirttula.Repository.Models;

namespace ShantiTirttula.Repository.Mappings
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
