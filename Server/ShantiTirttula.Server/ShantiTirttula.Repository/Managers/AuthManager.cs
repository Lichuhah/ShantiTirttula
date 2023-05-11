using ShantiTirttula.Domain.Dto;
using ShantiTirttula.Domain.Dto.Models;
using ShantiTirttula.Domain.Managers;
using ShantiTirttula.Domain.Models;
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
            McAuthDto dto = new McAuthDto
            {
                Id = entity.Id,
                Key = entity.Key,
                ProductId = entity.Product.Id,
                Mac = entity.Product.Mac
            };
            dto.TypeName = entity.Product.Name;
            dto.LastDateTime = entity.LastDateTime;
            dto.IsConnected = dto.LastDateTime > dto.LastDateTime - TimeSpan.FromHours(1) ? true : false;
            return dto;
        }

        public override IAuth ConvertFromDto(ApiDto<IAuth> data)
        {
            IAuth item;
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
