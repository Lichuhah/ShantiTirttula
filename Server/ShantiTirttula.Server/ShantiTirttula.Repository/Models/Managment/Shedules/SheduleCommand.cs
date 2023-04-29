using ShantiTirttula.Domain.Models;
using ShantiTirttula.Domain.Models.Managment.Shedules;

namespace ShantiTirttula.Repository.Models.Managment.Shedules
{
    public class SheduleCommand : Entity, ISheduleCommand
    {
        public virtual IDevice Device { get; set; }
        public virtual int Value { get; set; }
        public virtual IAuth Auth { get; set; }
        public virtual string Name { get; set; }
    }
}
