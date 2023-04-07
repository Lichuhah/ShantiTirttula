using NHibernate.Mapping.ByCode;
using ShantiTirttula.Repository.Models;
using ShantiTirttula.Repository.Models.Managment.Shedules;

namespace ShantiTirttula.Repository.Mappings.Managment.Shedules
{
    public class SheduleTaskMapping : EntityMapping<SheduleTask>
    {
        public SheduleTaskMapping() : base("AP_SHEDULE_TASK")
        {
            Property(x => x.StartDateTime, map =>
            {
                map.Column("START_DATETIME");
            });
            ManyToOne(x => x.Command, map =>
            {
                map.Column("COMMAND_ID");
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
