using ShantiTirttula.Server.Api.Controllers.Models;
using ShantiTirttula.Server.Api.Controllers.Models.Dto;
using ShantiTirttula.Server.Api.Domain.Implementations.Models;
using ShantiTirttula.Server.Api.Domain.Interfaces.Managers;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Managers
{
    public class TriggerTypeManager : EntityManager<ITriggerType>, ITriggerTypeManager
    {
        public TriggerTypeManager() : base()
        {

        }

        public override TriggerTypeDto ConvertToDto(ITriggerType entity)
        {
            TriggerTypeDto dto = new TriggerTypeDto();
            dto.Id = entity.Id;
            dto.Name = entity.Name;
            return dto;
        }

        public override ITriggerType ConvertFromDto(ApiDto<ITriggerType> data)
        {
            ITriggerType item;
            if (data.Id > 0)
                item = Get(data.Id);
            else
                item = new TriggerType();

            TriggerTypeDto dto = (TriggerTypeDto)data;
            item.Name = dto.Name;
            return item;
        }

        public override bool CheckUser(ITriggerType entity, IUser user)
        {
            return true;
        }
    }
}
