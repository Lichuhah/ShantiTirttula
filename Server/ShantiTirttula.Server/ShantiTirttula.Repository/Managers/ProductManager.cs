using ShantiTirttula.Domain.Managers;
using ShantiTirttula.Domain.Models;

namespace ShantiTirttula.Repository.Managers
{
    public class ProductManager : EntityManager<IProduct>, IProductManager
    {
        public ProductManager() : base()
        {

        }

    }
}
