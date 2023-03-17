using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Domain.Interfaces.Repositories
{
    public interface IEntityRepository<T> where T : IEntity
    {
        T Create();
        IQueryable<T> All();
        T Get(int id);
        T Save(T entity);
        bool Save(IEnumerable<T> entities);
        bool Delete(T entity);
        bool Delete(IEnumerable<T> entities);
    }
}
