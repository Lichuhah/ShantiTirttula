using ShantiTirttula.Server.Api.Controllers.Models;
using ShantiTirttula.Server.Api.Controllers.Models.Dto;
using ShantiTirttula.Server.Api.Domain.Implementations.Models;
using ShantiTirttula.Server.Api.Domain.Interfaces.Managers;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;
using ShantiTirttula.Server.Api.Domain.Interfaces.Repositories;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Managers
{
    public class McAuthManager : EntityManager<IMcAuth>, IMcAuthManager
    {
        public McAuthManager() : base()
        {

        }

        public override McAuthDto ConvertToDto(IMcAuth entity)
        {
            McAuthDto dto = new McAuthDto();
            dto.Id = entity.Id;
            dto.Key = entity.Key;
            dto.ControllerId = entity.Controller.Id;
            dto.Mac = entity.Controller.Mac;
            dto.TypeName = entity.Controller.Type.Name;
            return dto;
        }

        public override IMcAuth ConvertFromDto(ApiDto<IMcAuth> data)
        {
            IMcAuth item;
            if (data.Id > 0)
                item = Get(data.Id);
            else
                item = new McAuth();

            McAuthDto dto = (McAuthDto)data;
            item.Key = dto.Key;
            if(dto.ControllerId > 0)
            {
                item.Controller = new MicroControllerManager().Get(dto.ControllerId);
            }

            return item;
        }

        public override bool CheckUser(IMcAuth entity, IUser user)
        {
            return entity.User.Id == user.Id;
        }
    }
}
