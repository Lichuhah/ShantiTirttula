using ShantiTirttula.Domain.Models.Managment.Shedules;

namespace ShantiTirttula.Repository.Models.Managment.Shedules
{
    public class Shedule : Entity, IShedule
    {
        public virtual ISheduleCommand StartCommand { get; set; }
        public virtual ISheduleCommand EndCommand { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }
        public virtual int Period { get; set; }
    }
}
