using NHibernate.Mapping.ByCode;
using ShantiTirttula.Server.Api.Domain.Implementations.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Mappings
{
    public class ControllerMapping : EntityMapping<Controller>
    {
        public ControllerMapping() : base("MC_CONTROLLER")
        {
            Property(x => x.Mac, map =>
            {
                map.Column("MAC");
            });
            ManyToOne(x => x.Type, map =>
            {
                map.Column("TYPE_ID");
                map.Class(typeof(ControllerType));
                map.Lazy(LazyRelation.Proxy);
            });
            Bag(x => x.Sensors, map =>
            {
                map.Lazy(CollectionLazy.Lazy);
                map.BatchSize(30);
                map.Cascade(Cascade.All);
                map.Inverse(true);
                map.Key(key => { key.Column("CONTROLLER_ID"); });
            }, action => { action.OneToMany(x => { x.Class(typeof(Sensor)); }); });
            Bag(x => x.Devices, map =>
            {
                map.Lazy(CollectionLazy.Lazy);
                map.BatchSize(30);
                map.Cascade(Cascade.All);
                map.Inverse(true);
                map.Key(key => { key.Column("CONTROLLER_ID"); });
            }, action => { action.OneToMany(x => { x.Class(typeof(Device)); }); });
        }
    }
}
