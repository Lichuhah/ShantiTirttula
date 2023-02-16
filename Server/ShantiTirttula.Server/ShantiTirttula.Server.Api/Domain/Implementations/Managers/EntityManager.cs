using ShantiTirttula.Server.Api.Domain.Interfaces.Managers;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;
using ShantiTirttula.Server.Api.Domain.Interfaces.Repositories;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Managers
{
    public class EntityManager<T> : IEntityManager<T> where T : IEntity
    {
        protected readonly IEntityRepository<T> Repository;

        public EntityManager(IEntityRepository<T> repository)
        {
            Repository = repository;
        }
        public IQueryable<T> All()
        {
            return Repository.All();
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
    }
}
