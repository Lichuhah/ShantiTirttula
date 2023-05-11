using ShantiTirttula.Domain.Enums;
using ShantiTirttula.Domain.Models;

namespace ShantiTirttula.Repository.Models
{
    public class Auth : Entity, IAuth
    {
        public virtual string Key { get; set; }
        public virtual IUser User { get; set; }
        public virtual IList<ITrigger> Triggers { get; set; }
        public virtual IProduct Product { get; set; }
        public virtual ECommandProducerAlgorithm Producer { get; set; }
        public virtual DateTime LastDateTime { get; set; }
    }
}
