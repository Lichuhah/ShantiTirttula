using NHibernate.Mapping.ByCode;
using ShantiTirttula.Repository.Models;
using ShantiTirttula.Repository.Models.Managment.Shedules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShantiTirttula.Repository.Mappings.Managment.Shedules
{
    public class SheduleCommandMapping : EntityMapping<SheduleCommand>
    {
        public SheduleCommandMapping() : base("AP_SHEDULE_COMMAND")
        {
            Property(x => x.Value, map =>
            {
                map.Column("VALUE");
            });
            ManyToOne(x => x.Device, map =>
            {
                map.Column("DEVICE_ID");
                map.Class(typeof(Device));
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
