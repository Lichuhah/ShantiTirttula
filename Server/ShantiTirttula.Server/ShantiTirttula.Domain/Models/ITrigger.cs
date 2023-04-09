using ShantiTirttula.Domain.Models.Managment.Shedules;

namespace ShantiTirttula.Domain.Models
{
    public interface ITrigger : IEntityAuth
    {
        public new IAuth Auth { get; set; }
        public ITriggerType Type { get; set; }
        public ISensor Sensor { get; set; }
        public float TriggerValue { get; set; }
        public ISheduleCommand Command { get; set; }
        public bool IsAutonomy { get; set; }
        //public IList<ICommandLog> Logs { get; set; }
    }
}
