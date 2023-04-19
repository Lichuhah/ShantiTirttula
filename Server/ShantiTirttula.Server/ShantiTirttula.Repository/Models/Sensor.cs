using NHibernate.Linq;
using ShantiTirttula.Domain.Models;
using ShantiTirttula.Repository.Managers;
using System.Web.Mvc;

namespace ShantiTirttula.Repository.Models
{
    public class Sensor : Entity, ISensor
    {
        public virtual int Number { get; set; }
        public virtual IList<ISensorData> SensorDatas { get; set; }
        public virtual IMicroController Controller { get; set; }
        public virtual ISensorType Type { get; set; }
        public virtual IAuth Auth => new AuthManager().All().FirstOrDefault(x => x.Product == Controller);
    }
}
