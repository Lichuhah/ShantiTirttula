using ShantiTirttula.Domain.Dto;
using ShantiTirttula.Domain.Dto.Models;
using ShantiTirttula.Domain.Managers;
using ShantiTirttula.Domain.Models;
using ShantiTirttula.Repository.Models;

namespace ShantiTirttula.Repository.Managers
{
    public class TriggerTypeManager : EntityManager<ITriggerType>, ITriggerTypeManager
    {
        public TriggerTypeManager() : base()
        {

        }

        public override TriggerTypeDto ConvertToDto(ITriggerType entity)
        {
            TriggerTypeDto dto = new TriggerTypeDto
            {
                Id = entity.Id,
                Name = entity.Name
            };
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

    }
}
