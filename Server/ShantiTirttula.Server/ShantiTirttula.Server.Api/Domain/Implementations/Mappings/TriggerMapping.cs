using NHibernate.Mapping.ByCode;
using ShantiTirttula.Server.Api.Domain.Implementations.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Mappings
{
    public class TriggerMapping : EntityMapping<Trigger>
    {
        public TriggerMapping() : base("MC_TRIGGER")
        {
            Property(x => x.TriggerValue, map =>
            {
                map.Column("TRIGGER_VALUE");
            });
            Property(x => x.DeviceValue, map =>
            {
                map.Column("DEVICE_VALUE");
            });
            ManyToOne(x => x.Auth, map =>
            {
                map.Column("AUTH_ID");
                map.Class(typeof(McAuth));
                map.Lazy(LazyRelation.Proxy);
            });
            ManyToOne(x => x.Device, map =>
            {
                map.Column("DEVICE_ID");
                map.Class(typeof(Device));
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
        }
    }
}
