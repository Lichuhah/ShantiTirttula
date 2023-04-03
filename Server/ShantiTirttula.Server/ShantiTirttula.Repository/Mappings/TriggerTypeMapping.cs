using ShantiTirttula.Repository.Models;

namespace ShantiTirttula.Repository.Mappings
{
    public class TriggerTypeMapping : EntityMapping<TriggerType>
    {
        public TriggerTypeMapping() : base("MC_TRIGGER_TYPE")
        {
            Property(x => x.Name, map =>
            {
                map.Column("NAME");
            });
        }
    }
}
