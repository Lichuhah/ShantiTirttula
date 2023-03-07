using NHibernate.Mapping.ByCode;
using ShantiTirttula.Server.Api.Domain.Implementations.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Mappings
{
    public class DeviceLogMapping : EntityMapping<DeviceLog>
    {
        public DeviceLogMapping() : base("MC_DEVICE_LOG")
        {
            Property(x => x.Value, map =>
            {
                map.Column("VALUE");
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
        }
    }
}
