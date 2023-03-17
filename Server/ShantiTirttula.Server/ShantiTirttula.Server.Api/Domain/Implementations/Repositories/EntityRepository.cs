using ShantiTirttula.Server.Api.Domain.Helpers;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;
using ShantiTirttula.Server.Api.Domain.Interfaces.Repositories;
using NHibernate;
using System.Data;
using ShantiTirttula.Server.Api.Domain.Implementations.Models;
using DevExpress.XtraPrinting.Native;
using ISession = NHibernate.ISession;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Repositories
{
    public class EntityRepository<T> : IEntityRepository<T> where T : IEntity
    {
        NHibernateHelper helper;
        public EntityRepository()
        {
            helper = new NHibernateHelper();
        }

        public virtual IQueryable<T> All()
        {
            return helper.OpenSession().Query<T>();
        }

        public T Create()
        {
            //IEntity newEntity = (IEntity)Activator.CreateInstance(typeof(Entity));
            return (T)((IEntity)Activator.CreateInstance(typeof(Entity)));
        }

        public bool Delete(T entity)
        {
            ISession Session = helper.OpenSession();
            ITransaction transaction = Session.BeginTransaction(IsolationLevel.ReadCommitted);
            try
            {
                Session.Delete(entity);
                return true;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                transaction.Commit();
            }
        }

        public bool Delete(IEnumerable<T> entities)
        {
            try
            {
                foreach(var item in entities)
                {
                    this.Delete(item);
                }                
            }
            catch (Exception ex)
            {
                throw;
            }
            return true;
        }

        public T Get(int id)
        {
            ISession Session = helper.OpenSession();
            return Session.Get<T>(id);
        }

        public T Save(T entity)
        {
            ISession Session = helper.OpenSession();
            using ITransaction transaction = Session.BeginTransaction(IsolationLevel.ReadCommitted);
            try
            {
                entity.Id = (int)Session.Save(entity);
                return entity;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                transaction.Commit();
            }
        }

        public bool Save(IEnumerable<T> entities)
        {
            try
            {
                foreach (var item in entities)
                {
                    this.Save(item);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return true;
        }
    }
}
