using NHibernate.Mapping.ByCode;
using ShantiTirttula.Server.Api.Domain.Implementations.Models;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Mappings
{
    public class McAuthMapping : EntityMapping<McAuth>
    {
        public McAuthMapping() : base("MC_AUTH")
        {
            Property(x => x.Mac, map =>
            {
                map.Column("MAC");
            });
            Property(x => x.Key, map =>
            {
                map.Column("KEY");
            });
            ManyToOne(x => x.User, map =>
            {
                map.Column("USER_ID");
                map.Class(typeof(User));
                map.Lazy(LazyRelation.Proxy);
            });
        }    
    }
}
