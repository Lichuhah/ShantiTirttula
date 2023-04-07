using ShantiTirttula.Domain.Dto.Models;
using ShantiTirttula.Domain.Dto;
using ShantiTirttula.Domain.Managers;
using ShantiTirttula.Domain.Managers.Managment.Shedules;
using ShantiTirttula.Domain.Models.Managment.Shedules;
using ShantiTirttula.Repository.Models.Managment.Shedules;
using ShantiTirttula.Repository.Repositories;

namespace ShantiTirttula.Repository.Managers.Managment.Shedules
{
    public class SheduleTaskManager : EntityManager<ISheduleTask>, ISheduleTaskManager
    {
        public SheduleTaskManager() : base()
        {

        }

        public override SheduleTaskDto ConvertToDto(ISheduleTask entity)
        {
            SheduleTaskDto dto = new SheduleTaskDto();
            dto.Id = entity.Id;
            dto.StartDateTime = entity.StartDateTime;
            dto.Command = new SheduleCommandManager().ConvertToDto(entity.Command);
            dto.AuthId = entity.Auth.Id;
            return dto;
        }

        public override ISheduleTask ConvertFromDto(ApiDto<ISheduleTask> data)
        {
            ISheduleTask item;
            if (data.Id > 0)
                item = Get(data.Id);
            else
                item = new SheduleTask();

            SheduleTaskDto dto = (SheduleTaskDto)data;
            if (dto.AuthId > 0)
            {
                item.Auth = new AuthManager().Get(dto.AuthId);
            }
            if (dto.Command.Id > 0)
            {
                item.Command = new SheduleCommandManager().Get(dto.Command.Id);
            }
            item.StartDateTime = dto.StartDateTime;

            return item;
        }
    }
}
