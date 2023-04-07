namespace ShantiTirttula.Domain.Models.Managment.Shedules
{
    public interface ISheduleTask : IEntityAuth
    {
        public DateTime StartDateTime { get; set; }
        public ISheduleCommand Command { get; set; }
        public new IAuth Auth { get; set; }
    }
}
