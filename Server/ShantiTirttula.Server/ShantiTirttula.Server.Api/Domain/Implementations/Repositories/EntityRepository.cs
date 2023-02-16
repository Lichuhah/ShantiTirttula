using ShantiTirttula.Server.Api.Domain.Helpers;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;
using ShantiTirttula.Server.Api.Domain.Interfaces.Repositories;
using NHibernate;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Repositories
{
    public class EntityRepository<T> : IEntityRepository<T> where T : IEntity
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

        public bool Delete(T entity)
        {
            try
            {
                this.Session.Delete(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(IEnumerable<T> entities)
        {
            try
            {
                foreach(var item in entities)
                {
                    this.Session.Delete(item);
                }                
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public T Get(int id)
        {
            return Session.Get<T>(id);
        }

        public T Save(T entity)
        {
            try
            {
                Session.SaveOrUpdate(entity);
                Session.Flush();
            } catch (Exception ex)
            {
                var a = ex;
            }
            return entity;
        }

        public bool Save(IEnumerable<T> entities)
        {
            try
            {
                foreach (var item in entities)
                {
                    Session.SaveOrUpdate(item);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
