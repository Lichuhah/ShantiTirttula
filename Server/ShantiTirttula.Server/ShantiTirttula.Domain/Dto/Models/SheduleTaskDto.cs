using ShantiTirttula.Domain.Models.Managment.Shedules;

namespace ShantiTirttula.Domain.Dto.Models
{
    public class SheduleTaskDto : ApiDtoWithAuth<ISheduleTask>
    {
        public DateTime StartDateTime { get; set; }
        public CommandDto? Command { get; set; }
        public int? CommandId { get; set; }
    }
}
