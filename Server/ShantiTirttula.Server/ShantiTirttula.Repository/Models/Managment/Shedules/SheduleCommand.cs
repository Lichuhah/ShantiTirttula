using ShantiTirttula.Repository.Models;
using ShantiTirttula.Domain.Models.Managment.Shedules;
using ShantiTirttula.Repository.Managers.Managment.Shedules;
using ShantiTirttula.Domain.Models;
using ShantiTirttula.Repository.Managers;
using System.Web.Mvc;

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
