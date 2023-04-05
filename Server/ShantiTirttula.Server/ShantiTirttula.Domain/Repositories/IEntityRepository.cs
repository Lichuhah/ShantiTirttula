using NHibernate;
using ShantiTirttula.Domain.Models;

namespace ShantiTirttula.Domain.Repositories
{
    public interface IEntityRepository<T> where T : IEntity
    {
        public ISession Session { get; set; }
        T Create();
        IQueryable<T> All();
        T Get(int id);
        T Save(T entity);
        Task SaveAsync(T entity);
        bool Save(IEnumerable<T> entities);
        bool Delete(T entity);
        bool Delete(IEnumerable<T> entities);
    }
}
