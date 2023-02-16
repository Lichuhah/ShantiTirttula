using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Domain.Interfaces.Managers
{
    public interface IEntityManager<T> where T : IEntity
    {
        public IQueryable<T> All();
    }
}
