using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Domain.Interfaces.Managers
{
    public interface IEntityManager<T> where T : IEntity
    {
        public IQueryable<T> All();
        public T Get(int id);
        public T Save(T entity);
        public bool Save(IEnumerable<T> entities);
        public bool Delete(T entity);
        public bool Delete(IEnumerable<T> entities);
    }
}
