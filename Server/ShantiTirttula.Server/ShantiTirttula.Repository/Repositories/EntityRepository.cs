using NHibernate;
using System.Data;
using ISession = NHibernate.ISession;
using ShantiTirttula.Domain.Repositories;
using ShantiTirttula.Repository.Helpers;
using ShantiTirttula.Repository.Models;
using ShantiTirttula.Domain.Models;
using NHibernate.Context;

namespace ShantiTirttula.Repository.Repositories
{
    public class EntityRepository<T> : IEntityRepository<T> where T : IEntity
    {
        NHibernateHelper helper;
        ISession Session;
        public EntityRepository()
        {
            helper = new NHibernateHelper();
            Session = helper.OpenSession();
            CurrentSessionContext.Bind(Session);
        }

        public virtual IQueryable<T> All()
        { 
            using (ITransaction transaction = Session.BeginTransaction(IsolationLevel.ReadCommitted)) {
                try
                {
                    return helper.OpenSession().Query<T>();
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
                try
                {
                    return Session.Get<T>(id);
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
