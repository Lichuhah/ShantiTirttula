using NHibernate;
using ShantiTirttula.Domain.Dto;
using ShantiTirttula.Domain.Models;
using ShantiTirttula.Domain.Repositories;

namespace ShantiTirttula.Domain.Managers
{
    public interface IEntityManager<T> where T : IEntity
    {
        public ISession GetSession();
        public void SetSession(ISession session);
        public IQueryable<T> All();
        public IQueryable<T> AllAllowed(IUser user);
        public T Create();
        public T Get(int id);
        public T Save(T entity);
        public Task SaveAsync(T entity);
        public bool Save(IEnumerable<T> entities);
        public bool Delete(T entity);
        public bool Delete(IEnumerable<T> entities);
        public ApiDto<T> ConvertToDto(T entity);
        public T ConvertFromDto(ApiDto<T> entity);
    }
}
