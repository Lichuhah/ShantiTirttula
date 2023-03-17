using ShantiTirttula.Server.Api.Controllers.Models;
using ShantiTirttula.Server.Api.Controllers.Models.Dto;
using ShantiTirttula.Server.Api.Domain.Implementations.Models;
using ShantiTirttula.Server.Api.Domain.Interfaces.Managers;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Managers
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
            UserDto dto = new UserDto();
            dto.Id = entity.Id;
            dto.Login = entity.Login;
            dto.Password = entity.Password;
            return dto;
        }

        public override IUser ConvertFromDto(ApiDto<IUser> entity)
        {
            IUser item;
            if (entity.Id>0)
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
