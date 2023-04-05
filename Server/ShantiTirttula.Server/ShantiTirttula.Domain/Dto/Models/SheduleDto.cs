using ShantiTirttula.Domain.Models.Managment.Shedules;

namespace ShantiTirttula.Domain.Dto.Models
{
    public class SheduleDto : ApiDto<IShedule>
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int StartCommandId { get; set; }
        public int EndCommandId { get; set; }
        public int Period { get; set; }
    }
}
