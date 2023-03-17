using NHibernate.Mapping.ByCode;
using ShantiTirttula.Server.Api.Domain.Implementations.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Mappings
{
    public class MicroControllerTypeMapping : EntityMapping<MicroControllerType>
    {
        public MicroControllerTypeMapping() : base("MC_CONTROLLER_TYPE")
        {
            Property(x => x.Name, map =>
            {
                map.Column("NAME");
            });
            Bag(x => x.Controllers, map =>
            {
                map.Lazy(CollectionLazy.Lazy);
                map.BatchSize(30);
                map.Cascade(Cascade.All);
                map.Inverse(true);
                map.Key(key => { key.Column("TYPE_ID"); });
            }, action => { action.OneToMany(x => { x.Class(typeof(MicroController)); }); });
        }
    }
}
