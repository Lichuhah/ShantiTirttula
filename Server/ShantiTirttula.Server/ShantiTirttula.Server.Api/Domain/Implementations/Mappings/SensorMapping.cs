using NHibernate.Mapping.ByCode;
using ShantiTirttula.Server.Api.Domain.Implementations.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Mappings
{
    public class SensorMapping : EntityMapping<Sensor>
    {
        public SensorMapping() : base("MC_SENSOR")
        {
            Property(x => x.Number, map =>
            {
                map.Column("NUMBER");
            }); 
            ManyToOne(x => x.Auth, map =>
            {
                map.Column("AUTH_ID");
                map.Class(typeof(McAuth));
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
