namespace ShantiTirttula.Domain.Models.Managment.Shedules
{
    public interface ISheduleCommand : IEntityAuth
    {
        public new IAuth Auth { get; set; }
        public IDevice Device { get; set; }
        public int Value { get; set; }
    }
}
