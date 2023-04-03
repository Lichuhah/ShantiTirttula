using NHibernate.Mapping.ByCode;
using ShantiTirttula.Repository.Models;

namespace ShantiTirttula.Repository.Mappings
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
