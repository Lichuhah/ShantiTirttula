using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using ShantiTirttula.Repository.Models;

namespace ShantiTirttula.Repository.Mappings
{
    public class EntityMapping<T> : ClassMapping<T> where T : Entity
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
