using NHibernate.Mapping.ByCode;
using ShantiTirttula.Repository.Models;

namespace ShantiTirttula.Repository.Mappings
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
                map.Class(typeof(Auth));
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
