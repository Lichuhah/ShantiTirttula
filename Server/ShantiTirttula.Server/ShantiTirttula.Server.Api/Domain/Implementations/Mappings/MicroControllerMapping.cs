using NHibernate.Mapping.ByCode;
using ShantiTirttula.Server.Api.Domain.Implementations.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Mappings
{
    public class MicroControllerMapping : EntityMapping<MicroController>
    {
        public MicroControllerMapping() : base("MC_CONTROLLER")
        {
            ManyToOne(x => x.Type, map =>
            {
                map.Column("TYPE_ID");
                map.Class(typeof(MicroControllerType));
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
