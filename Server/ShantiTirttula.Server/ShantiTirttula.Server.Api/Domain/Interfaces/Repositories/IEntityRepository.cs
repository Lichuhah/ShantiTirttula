using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Domain.Interfaces.Repositories
{
    public interface IEntityRepository<T> where T : IEntity
    {
        IQueryable<T> All();
    }
}
