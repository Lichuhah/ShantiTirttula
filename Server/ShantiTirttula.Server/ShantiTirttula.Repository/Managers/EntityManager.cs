using ShantiTirttula.Domain.Dto;
using ShantiTirttula.Domain.Managers;
using ShantiTirttula.Domain.Models;
using ShantiTirttula.Domain.Repositories;
using ShantiTirttula.Repository.Repositories;

namespace ShantiTirttula.Repository.Managers
{
    public class EntityManager<T> : IEntityManager<T> where T : IEntity
    {
        protected readonly IEntityRepository<T> Repository;

        public EntityManager()
        {
            Repository = new EntityRepository<T>();
        }

        public NHibernate.ISession Session { get; set; }

        public virtual IQueryable<T> All()
        {
            return Repository.All();
        }
        public virtual IQueryable<T> AllAllowed(IUser user)
        {
            return Repository.All().ToList().AsQueryable();
        }
        public virtual T Create()
        {
            return Repository.Create();
        }

        public virtual bool Delete(T entity)
        {
            return Repository.Delete(entity);
        }

        public virtual bool Delete(IEnumerable<T> entities)
        {
            return Repository.Delete(entities);
        }

        public virtual T Get(int id)
        {
            return Repository.Get(id);
        }

        public virtual T Save(T entity)
        {
            return Repository.Save(entity);
        }

        public virtual bool Save(IEnumerable<T> entities)
        {
            return Repository.Save(entities);
        }

        public virtual ApiDto<T> ConvertToDto(T entity)
        {
            ApiDto<T> dto = new ApiDto<T>();
            return dto;
        }

        public virtual T ConvertFromDto(ApiDto<T> entity)
        {
            T item = Create();
            return item;
        }
    }
}
