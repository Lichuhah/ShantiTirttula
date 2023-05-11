using NHibernate.Mapping.ByCode;
using ShantiTirttula.Repository.Models;

namespace ShantiTirttula.Repository.Mappings
{
    public class ProductMapping : EntityMapping<Product>
    {
        public ProductMapping() : base("MC_PRODUCT")
        {
            Property(x => x.Mac, map =>
            {
                map.Column("MAC");
            });
            Property(x => x.Name, map =>
            {
                map.Column("NAME");
            });
            ManyToOne(x => x.Controller, map =>
            {
                map.Column("CONTROLLER_ID");
                map.Class(typeof(MicroController));
                map.Lazy(LazyRelation.NoLazy);
            });
        }
    }
}
