using ShantiTirttula.Server.Api.Domain.Interfaces.Managers;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Managers
{
    public class UserManager : EntityManager<IUser>, IUserManager
    {
        public UserManager(NHibernate.ISession session) : base(session)
        {

        }

        public IUser CheckLogin(string login, string password)
        {
            return Repository.All().FirstOrDefault(x => x.Login == login && x.Password == password);
        }
    }
}
