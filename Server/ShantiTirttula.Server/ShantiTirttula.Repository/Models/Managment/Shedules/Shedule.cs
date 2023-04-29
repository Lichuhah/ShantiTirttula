using ShantiTirttula.Domain.Models;
using ShantiTirttula.Domain.Models.Managment.Shedules;

namespace ShantiTirttula.Repository.Models.Managment.Shedules
{
    public class Shedule : Entity, IShedule
    {
        public virtual ISheduleCommand StartCommand { get; set; }
        public virtual ISheduleCommand EndCommand { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }
        public virtual int PeriodCounter { get { return (int)Math.Truncate((DateTime.UtcNow - LastExecutionTime).TotalDays); } }
        public virtual int Period { get; set; }
        public virtual DateTime LastExecutionTime { get; set; }
        public virtual IAuth Auth { get; set; }
    }
}
