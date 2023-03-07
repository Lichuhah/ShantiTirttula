using NHibernate.Mapping.ByCode;
using ShantiTirttula.Server.Api.Domain.Implementations.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Mappings
{
    public class DeviceMapping : EntityMapping<Device>
    {
        public DeviceMapping() : base("MC_DEVICE")
        {
            Property(x => x.Pin, map =>
            {
                map.Column("PIN");
            });
            Property(x => x.IsAnalog, map =>
            {
                map.Column("ANALOG");
            });
            ManyToOne(x => x.Controller, map =>
            {
                map.Column("CONTROLLER_ID");
                map.Class(typeof(Controller));
                map.Lazy(LazyRelation.Proxy);
            }); 
            ManyToOne(x => x.Type, map =>
            {
                map.Column("TYPE_ID");
                map.Class(typeof(DeviceType));
                map.Lazy(LazyRelation.Proxy);
            });
            Bag(x => x.Logs, map =>
            {
                map.Lazy(CollectionLazy.Lazy);
                map.BatchSize(30);
                map.Cascade(Cascade.All);
                map.Inverse(true);
                map.Key(key => { key.Column("DEVICE_ID"); });
            }, action => { action.OneToMany(x => { x.Class(typeof(DeviceLog)); }); });
        }
    }
}
