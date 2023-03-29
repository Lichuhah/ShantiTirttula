using NHibernate.Mapping.ByCode;
using ShantiTirttula.Server.Api.Domain.Implementations.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Mappings
{

    public class CommandLogMapping : EntityMapping<CommandLog>
    {
        public CommandLogMapping() : base("MC_COMMAND_LOG")
        {
            Property(x => x.DateTime, map =>
            {
                map.Column("DATETIME");
            });
            ManyToOne(x => x.Auth, map =>
            {
                map.Column("AUTH_ID");
                map.Class(typeof(McAuth));
                map.Lazy(LazyRelation.Proxy);
            });
            ManyToOne(x => x.Trigger, map =>
            {
                map.Column("TRIGGER_ID");
                map.Class(typeof(Trigger));
                map.Lazy(LazyRelation.Proxy);
            });
        }
    }
}
