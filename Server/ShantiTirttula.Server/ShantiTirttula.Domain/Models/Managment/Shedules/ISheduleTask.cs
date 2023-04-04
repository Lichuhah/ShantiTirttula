namespace ShantiTirttula.Domain.Models.Managment.Shedules
{
    public interface ISheduleTask : IEntity
    {
        public DateTime StartDateTime { get; set; }
        public ISheduleCommand Command { get; set; }
    }
}
