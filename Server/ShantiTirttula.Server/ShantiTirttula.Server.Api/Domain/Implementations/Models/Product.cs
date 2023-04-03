using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Models
{
    public class Product : Entity, IProduct
    {
        public virtual string Mac { get; set; }
        public virtual IMicroController Controller { get; set; }
    }
}
