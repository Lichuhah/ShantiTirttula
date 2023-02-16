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
    }
}
