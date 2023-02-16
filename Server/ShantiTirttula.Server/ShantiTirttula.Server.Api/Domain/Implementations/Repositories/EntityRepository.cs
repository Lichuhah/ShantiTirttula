using ShantiTirttula.Server.Api.Domain.Helpers;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;
using ShantiTirttula.Server.Api.Domain.Interfaces.Repositories;
using NHibernate;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Repositories
{
    public class EntityRepository<T> : IEntityRepository<T> where T:IEntity
    {
        NHibernate.ISession Session;
        public EntityRepository(NHibernate.ISession session)
        {
            this.Session = session;
        }

        public virtual IQueryable<T> All()
        {
            return Session.Query<T>();
        }
    }
}
