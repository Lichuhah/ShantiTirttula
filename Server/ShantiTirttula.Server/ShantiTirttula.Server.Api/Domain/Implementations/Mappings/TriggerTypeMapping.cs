using ShantiTirttula.Server.Api.Domain.Implementations.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Mappings
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
