using ShantiTirttula.Domain.Dto;
using ShantiTirttula.Domain.Dto.Models;
using ShantiTirttula.Domain.Managers;
using ShantiTirttula.Domain.Models;
using ShantiTirttula.Repository.Models;

namespace ShantiTirttula.Repository.Managers
{
    public class UserManager : EntityManager<IUser>, IUserManager
    {
        public UserManager() : base()
        {

        }

        public IUser CheckLogin(string login, string password)
        {
            return Repository.All().FirstOrDefault(x => x.Login == login && x.Password == password);
        }

        public override UserDto ConvertToDto(IUser entity)
        {
            UserDto dto = new UserDto
            {
                Id = entity.Id,
                Login = entity.Login,
                Password = entity.Password
            };
            return dto;
        }

        public override IUser ConvertFromDto(ApiDto<IUser> entity)
        {
            IUser item;
            if (entity.Id > 0)
                item = Get(entity.Id);
            else
                item = new User();

            UserDto dto = (UserDto)entity;
            item.Login = dto.Login;
            item.Password = dto.Password;
            return item;
        }
    }
}
