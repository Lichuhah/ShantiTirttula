using NHibernate.Mapping.ByCode;
using ShantiTirttula.Server.Api.Domain.Implementations.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Mappings
{
    public class SensorDataMapping : EntityMapping<SensorData>
    {
        public SensorDataMapping() : base("AP_SENSOR_DATA")
        {
            Property(x => x.Value, map =>
            {
                map.Column("VALUE");
            });
            ManyToOne(x => x.Sensor, map =>
            {
                map.Column("SENSOR_ID");
                map.Class(typeof(Sensor));
                map.Lazy(LazyRelation.Proxy);
            }); 
            ManyToOne(x => x.Auth, map =>
            {
                map.Column("AUTH_ID");
                map.Class(typeof(Auth));
                map.Lazy(LazyRelation.Proxy);
            });
        }
    }
}
