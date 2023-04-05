namespace ShantiTirttula.Domain.Models.Managment.Shedules
{
    public interface IShedule : IEntity
    {
        public ISheduleCommand StartCommand { get; set; }
        public ISheduleCommand EndCommand { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Period { get; set; }
        public int PeriodCounter { get; }
        public DateTime LastExecutionTime { get; set; }
    }
}
