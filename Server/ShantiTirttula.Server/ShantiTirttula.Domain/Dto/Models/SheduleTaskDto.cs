using ShantiTirttula.Domain.Models.Managment.Shedules;

namespace ShantiTirttula.Domain.Dto.Models
{
    public class SheduleTaskDto : ApiDto<ISheduleTask>
    {
        public DateTime StartDateTime { get; set; }
        public int CommandId { get; set; }
    }
}
