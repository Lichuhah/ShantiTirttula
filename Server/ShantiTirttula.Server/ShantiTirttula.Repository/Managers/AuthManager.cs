using ShantiTirttula.Domain.Managers;
using ShantiTirttula.Domain.Models;
using ShantiTirttula.Domain.Dto;
using ShantiTirttula.Domain.Dto.Models;
using ShantiTirttula.Repository.Models;

namespace ShantiTirttula.Repository.Managers
{
    public class AuthManager : EntityManager<IAuth>, IAuthManager
    {
        public AuthManager() : base()
        {

        }

        public override McAuthDto ConvertToDto(IAuth entity)
        {
            McAuthDto dto = new McAuthDto();
            dto.Id = entity.Id;
            dto.Key = entity.Key;
            dto.ProductId = entity.Product.Id;
            dto.Mac = entity.Product.Mac;
            //dto.TypeName = entity.Controller.Type.Name;
            return dto;
        }

        public override IAuth ConvertFromDto(ApiDto<IAuth> data)
        {
            IAuth item
            if (data.Id > 0)
                item = Get(data.Id);
            else
                item = new Auth();

            McAuthDto dto = (McAuthDto)data;
            item.Key = dto.Key;
            if (dto.ProductId > 0)
            {
                item.Product = new ProductManager().Get(dto.ProductId);
            }

            return item;
        }
    }
}
