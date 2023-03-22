using ShantiTirttula.Server.Api.Controllers.Models;
using ShantiTirttula.Server.Api.Domain.Helpers;
using ShantiTirttula.Server.Api.Domain.Implementations.Repositories;
using ShantiTirttula.Server.Api.Domain.Interfaces.Managers;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;
using ShantiTirttula.Server.Api.Domain.Interfaces.Repositories;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Managers
{
    public class EntityManager<T> : IEntityManager<T> where T : IEntity
    {
        protected readonly IEntityRepository<T> Repository;

        public EntityManager()
        {
            Repository = new EntityRepository<T>();
        }

        public NHibernate.ISession Session { get; set; }

        public IQueryable<T> All()
        {
            return Repository.All();
        }
        public IQueryable<T> AllAllowed(IUser user)
        {
            return Repository.All().ToList().Where(x => CheckUser(x, user) == true).AsQueryable();
        }
        public T Create()
        {
            return Repository.Create();
        }

        public bool Delete(T entity)
        {
            return Repository.Delete(entity);
        }

        public bool Delete(IEnumerable<T> entities)
        {
            return Repository.Delete(entities);
        }

        public T Get(int id)
        {
            return Repository.Get(id);
        }

        public T Save(T entity)
        {
            return Repository.Save(entity);
        }

        public bool Save(IEnumerable<T> entities)
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

        public virtual bool CheckUser(T entity, IUser user)
        {
            return true;
        }
    }
}
