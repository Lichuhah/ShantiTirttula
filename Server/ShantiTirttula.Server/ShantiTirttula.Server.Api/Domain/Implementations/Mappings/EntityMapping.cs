using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;
using ShantiTirttula.Server.Api.Domain.Implementations.Models;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Mappings
{
    public class EntityMapping<T> : ClassMapping<T> where T:Entity
    {
        public EntityMapping(string tableName)
        {
            if (!string.IsNullOrEmpty(tableName))
            {
                Table(tableName);
            }
            Id(x => x.Id, map =>
            {
                map.Column("ID");
                map.Generator(Generators.Native, gen => { gen.Params(new { sequence = tableName + "_id_seq" }); });
            });
        }
    }
}
