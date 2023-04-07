using NHibernate.Mapping.ByCode;
using ShantiTirttula.Repository.Models;
using ShantiTirttula.Repository.Models.Managment.Shedules;

namespace ShantiTirttula.Repository.Mappings.Managment.Shedules
{
    public class SheduleMapping : EntityMapping<Shedule>
    {
        public SheduleMapping() : base("AP_SHEDULE")
        {
            Property(x => x.Period, map =>
            {
                map.Column("PERIOD");
            });
            Property(x => x.LastExecutionTime, map =>
            {
                map.Column("LAST_EXECUTION_TIME");
            });
            Property(x => x.StartTime, map =>
            {
                map.Column("START_TIME");
            });
            Property(x => x.EndTime, map =>
            {
                map.Column("END_TIME");
            });
            ManyToOne(x => x.StartCommand, map =>
            {
                map.Column("START_COMMAND_ID");
                map.Class(typeof(SheduleCommand));
                map.Lazy(LazyRelation.Proxy);
            });
            ManyToOne(x => x.EndCommand, map =>
            {
                map.Column("END_COMMAND_ID");
                map.Class(typeof(SheduleCommand));
                map.Lazy(LazyRelation.Proxy);
            });
            ManyToOne(x => x.Auth, map =>
            {
                map.Column("AUTH_ID");
                map.Class(typeof(Auth));
                map.Lazy(LazyRelation.Proxy);
            });
        }
    }
}
