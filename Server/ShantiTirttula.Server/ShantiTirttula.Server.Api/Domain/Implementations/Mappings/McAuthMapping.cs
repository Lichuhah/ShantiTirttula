using NHibernate.Mapping.ByCode;
using ShantiTirttula.Server.Api.Domain.Implementations.Models;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Mappings
{
    public class McAuthMapping : EntityMapping<McAuth>
    {
        public McAuthMapping() : base("MC_CONTROLLER_AUTH")
        {
            Property(x => x.Key, map =>
            {
                map.Column("KEY");
            });
            ManyToOne(x => x.User, map =>
            {
                map.Column("USER_ID");
                map.Class(typeof(User));
                map.Lazy(LazyRelation.NoLazy);
            });
            ManyToOne(x => x.Controller, map =>
            {
                map.Column("CONTROLLER_ID");
                map.Class(typeof(MicroController));
                map.Lazy(LazyRelation.Proxy);
            });
            Bag(x => x.Triggers, map =>
            {
                map.Lazy(CollectionLazy.Lazy);
                map.BatchSize(30);
                map.Cascade(Cascade.All);
                map.Inverse(true);
                map.Key(key => { key.Column("AUTH_ID"); });
            }, action => { action.OneToMany(x => { x.Class(typeof(Trigger)); }); });
        }    
    }
}
