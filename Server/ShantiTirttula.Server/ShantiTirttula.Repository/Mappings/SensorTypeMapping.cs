using NHibernate.Mapping.ByCode;
using ShantiTirttula.Repository.Models;

namespace ShantiTirttula.Repository.Mappings
{
    public class SensorTypeMapping : EntityMapping<SensorType>
    {
        public SensorTypeMapping() : base("MC_SENSOR_TYPE")
        {
            Property(x => x.Name, map =>
            {
                map.Column("NAME");
            });
            Property(x => x.Unit, map =>
            {
                map.Column("UNIT");
            });
            Property(x => x.Power, map =>
            {
                map.Column("POWER");
            });
            Property(x => x.MaxValue, map =>
            {
                map.Column("MAX_VALUE");
            });
            Property(x => x.MinValue, map =>
            {
                map.Column("MIN_VALUE");
            });
            Property(x => x.Algorithm, map =>
            {
                map.Column("ALGORITHM");
            });
            Property(x => x.IsReverse, map =>
            {
                map.Column("REVERSE");
            });
            Bag(x => x.Sensors, map =>
            {
                map.Lazy(CollectionLazy.Lazy);
                map.BatchSize(30);
                map.Cascade(Cascade.All);
                map.Inverse(true);
                map.Key(key => { key.Column("TYPE_ID"); });
            }, action => { action.OneToMany(x => { x.Class(typeof(Sensor)); }); });
        }
    }
}
