using ShantiTirttula.Domain.Models;

namespace ShantiTirttula.Repository.Models
{
    public class Product : Entity, IProduct
    {
        public virtual string Name { get; set; }
        public virtual string Mac { get; set; }
        public virtual IMicroController Controller { get; set; }
    }
}
