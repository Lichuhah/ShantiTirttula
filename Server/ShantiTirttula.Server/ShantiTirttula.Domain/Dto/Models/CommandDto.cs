using ShantiTirttula.Domain.Models.Managment.Shedules;

namespace ShantiTirttula.Domain.Dto.Models
{
    public class CommandDto : ApiDtoWithAuth<ISheduleCommand>
    {
        public int Pin { get; set; }
        public bool IsPwm { get; set; }
        public double Value { get; set; }
    }
}
