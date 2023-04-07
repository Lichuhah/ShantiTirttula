using ShantiTirttula.Domain.Models;
using ShantiTirttula.Domain.Models.Managment.Shedules;

namespace ShantiTirttula.Repository.Models.Managment.Shedules
{
    public class SheduleTask : Entity, ISheduleTask
    {
        public virtual DateTime StartDateTime { get; set; }
        public virtual ISheduleCommand Command { get; set; }
        public virtual IAuth Auth { get; set; }
    }
}
