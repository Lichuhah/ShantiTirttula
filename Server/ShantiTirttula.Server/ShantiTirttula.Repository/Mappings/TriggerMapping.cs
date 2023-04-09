using NHibernate.Mapping.ByCode;
using ShantiTirttula.Repository.Models;
using ShantiTirttula.Repository.Models.Managment.Shedules;

namespace ShantiTirttula.Repository.Mappings
{
    public class TriggerMapping : EntityMapping<Trigger>
    {
        public TriggerMapping() : base("MC_TRIGGER")
        {
            Property(x => x.TriggerValue, map =>
            {
                map.Column("TRIGGER_VALUE");
            });
            Property(x => x.IsAutonomy, map =>
            {
                map.Column("AUTONOMY");
            });
            ManyToOne(x => x.Auth, map =>
            {
                map.Column("AUTH_ID");
                map.Class(typeof(Auth));
                map.Lazy(LazyRelation.Proxy);
            });
            ManyToOne(x => x.Command, map =>
            {
                map.Column("COMMAND_ID");
                map.Class(typeof(SheduleCommand));
                map.Lazy(LazyRelation.Proxy);
            });
            ManyToOne(x => x.Sensor, map =>
            {
                map.Column("SENSOR_ID");
                map.Class(typeof(Sensor));
                map.Lazy(LazyRelation.Proxy);
            });
            ManyToOne(x => x.Type, map =>
            {
                map.Column("TYPE_ID");
                map.Class(typeof(TriggerType));
                map.Lazy(LazyRelation.Proxy);
            });
            //Bag(x => x.Logs, map =>
            //{
            //    map.Lazy(CollectionLazy.Lazy);
            //    map.BatchSize(30);
            //    map.Cascade(Cascade.All);
            //    map.Inverse(true);
            //    map.Key(key => { key.Column("TRIGGER_ID"); });
            //}, action => { action.OneToMany(x => { x.Class(typeof(CommandLog)); }); });
        }
    }
}
