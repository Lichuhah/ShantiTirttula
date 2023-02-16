using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;
using ShantiTirttula.Server.Api.Domain.Implementations.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Mappings
{
    public class EntityMapping : ClassMapping<Entity>
    {
        public EntityMapping()
        {
            //if (!string.IsNullOrEmpty(tableName))
            //{
            //    Table(tableName);
            //}
            Table("ENTITY");
            Id(x => x.Id, map =>
            {
                map.Column("ID");
                map.Generator(Generators.Native, gen => { gen.Params(new { sequence = "ENTITY" + "_id_seq" }); });
            });
            Property(x => x.Test, map =>
            {
                map.Column("TEST");
            });
        }
    }
}
