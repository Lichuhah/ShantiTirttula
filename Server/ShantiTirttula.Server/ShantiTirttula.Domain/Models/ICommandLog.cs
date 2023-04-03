namespace ShantiTirttula.Domain.Models
{
    public interface ICommandLog : IEntityAuth
    {
        public ITrigger Trigger { get; set; }
        public DateTime DateTime { get; set; }
    }
}
