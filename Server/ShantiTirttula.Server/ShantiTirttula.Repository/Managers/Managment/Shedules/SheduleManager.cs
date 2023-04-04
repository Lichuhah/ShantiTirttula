using ShantiTirttula.Domain.Managers.Managment.Shedules;
using ShantiTirttula.Domain.Models.Managment.Shedules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShantiTirttula.Repository.Managers.Managment.Shedules
{
    public class SheduleManager : EntityManager<IShedule>, ISheduleManager
    {
        public SheduleManager() : base()
        {

        }
    }
}
