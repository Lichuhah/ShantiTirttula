using ShantiTirttula.Domain.Models;
using ShantiTirttula.Domain.Models.Managment.Shedules;

namespace ShantiTirttula.Repository.Models
{
    public class Trigger : Entity, ITrigger
    {
        public virtual ITriggerType Type { get; set; }
        public virtual ISensor Sensor { get; set; }
        public virtual IDevice Device { get; set; }
        public virtual float TriggerValue { get; set; }
        public virtual float DeviceValue { get; set; }
        //public virtual IList<ICommandLog> Logs { get; set; }
        public virtual IAuth Auth { get; set; }
        public virtual bool IsAutonomy { get; set; }
        public virtual ISheduleCommand Command { get; set; }
    }
}
