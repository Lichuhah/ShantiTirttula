namespace ShantiTirttula.Domain.Models.Managment.Shedules
{
    public interface ISheduleCommand : IEntity
    {
        public IDevice Device { get; set; }
        public int Value { get; set; }
    }
}
