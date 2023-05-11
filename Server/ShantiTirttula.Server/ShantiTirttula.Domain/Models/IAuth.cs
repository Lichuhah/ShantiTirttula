using ShantiTirttula.Domain.Enums;

namespace ShantiTirttula.Domain.Models
{
    public interface IAuth : IEntity
    {
        public string Key { get; set; }
        public IUser User { get; set; }
        public IList<ITrigger> Triggers { get; set; }
        public IProduct Product { get; set; }
        public ECommandProducerAlgorithm Producer { get; set; }
        public DateTime LastDateTime { get; set; }
    }
}
