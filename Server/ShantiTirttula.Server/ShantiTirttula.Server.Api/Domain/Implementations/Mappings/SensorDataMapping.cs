using ShantiTirttula.Server.Api.Domain.Implementations.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Mappings
{
    public class SensorDataMapping : EntityMapping<SensorData>
    {
        public SensorDataMapping() : base("MC_SENSOR_DATA")
        {
            Property(x => x.Value, map =>
            {
                map.Column("VALUE");
            });
            Property(x => x.DateTime, map =>
            {
                map.Column("DATETIME");
            });
        }
    }
}
