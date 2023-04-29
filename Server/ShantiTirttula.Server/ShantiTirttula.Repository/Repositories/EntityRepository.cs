using NHibernate;
using NHibernate.Context;
using ShantiTirttula.Domain.Models;
using ShantiTirttula.Domain.Repositories;
using ShantiTirttula.Repository.Helpers;
using ShantiTirttula.Repository.Models;
using System.Data;
using ISession = NHibernate.ISession;

namespace ShantiTirttula.Repository.Repositories
{
    public class EntityRepository<T> : IEntityRepository<T> where T : IEntity
    {
        private NHibernateHelper helper;
        public ISession Session { get; set; }
        public EntityRepository()
        {
            helper = new NHibernateHelper();
            Session = helper.OpenSession();
            CurrentSessionContext.Bind(Session);
        }

        public EntityRepository(ISession session)
        {
            Session = session;
            CurrentSessionContext.Bind(Session);
        }
        public virtual IQueryable<T> All()
        {
            using (ITransaction transaction = Session.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                return Session.Query<T>();
            }
        }

        public T Create()
        {
            //IEntity newEntity = (IEntity)Activator.CreateInstance(typeof(Entity));
            return (T)(IEntity)Activator.CreateInstance(typeof(Entity));
        }

        public bool Delete(T entity)
        {
            using (ITransaction transaction = Session.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    Session.Delete(Session.Get<T>(entity.Id));
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
        }

        public bool Delete(IEnumerable<T> entities)
        {
            try
            {
                foreach (var item in entities)
                {
                    Delete(item);
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
            using (ITransaction transaction = Session.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                return Session.Get<T>(id);
            }
        }

        public T Save(T entity)
        {
            using (ITransaction transaction = Session.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    entity.Id = (int)Session.Save(entity);
                    return entity;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    transaction.Commit();
                }
            }
        }

        public async Task SaveAsync(T entity)
        {
            using (ITransaction transaction = Session.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    await Session.SaveAsync(entity);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    transaction.Commit();
                }
            }
        }

        public bool Save(IEnumerable<T> entities)
        {
            try
            {
                foreach (var item in entities)
                {
                    Save(item);
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
