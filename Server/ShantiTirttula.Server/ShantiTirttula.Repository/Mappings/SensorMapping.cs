using NHibernate.Mapping.ByCode;
using ShantiTirttula.Repository.Models;

namespace ShantiTirttula.Repository.Mappings
{
    public class SensorMapping : EntityMapping<Sensor>
    {
        public SensorMapping() : base("MC_SENSOR")
        {
            Property(x => x.Number, map =>
            {
                map.Column("NUMBER");
            });
            ManyToOne(x => x.Controller, map =>
            {
                map.Column("CONTROLLER_ID");
                map.Class(typeof(MicroController));
                map.Lazy(LazyRelation.Proxy);
            });
            ManyToOne(x => x.Type, map =>
            {
                map.Column("TYPE_ID");
                map.Class(typeof(SensorType));
                map.Lazy(LazyRelation.Proxy);
            });
            Bag(x => x.SensorDatas, map =>
            {
                map.Lazy(CollectionLazy.Lazy);
                map.BatchSize(30);
                map.Cascade(Cascade.All);
                map.Inverse(true);
                map.Key(key => { key.Column("SENSOR_ID"); });
            }, action => { action.OneToMany(x => { x.Class(typeof(SensorData)); }); });
        }
    }
}
