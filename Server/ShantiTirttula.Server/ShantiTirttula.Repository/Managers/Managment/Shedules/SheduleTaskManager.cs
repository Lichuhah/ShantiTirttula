using ShantiTirttula.Domain.Dto;
using ShantiTirttula.Domain.Dto.Models;
using ShantiTirttula.Domain.Managers.Managment.Shedules;
using ShantiTirttula.Domain.Models.Managment.Shedules;
using ShantiTirttula.Repository.Models.Managment.Shedules;

namespace ShantiTirttula.Repository.Managers.Managment.Shedules
{
    public class SheduleTaskManager : EntityManager<ISheduleTask>, ISheduleTaskManager
    {
        public SheduleTaskManager() : base()
        {

        }

        public override SheduleTaskDto ConvertToDto(ISheduleTask entity)
        {
            SheduleTaskDto dto = new SheduleTaskDto
            {
                Id = entity.Id,
                StartDateTime = DateTime.SpecifyKind(entity.StartDateTime, DateTimeKind.Utc),
                Command = new SheduleCommandManager().ConvertToDto(entity.Command),
                AuthId = entity.Auth.Id
            };
            dto.CommandId = dto.Command.Id;
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
                item.Auth = new AuthManager().Get(dto.AuthId);

            if (dto.Command != null)
            {
                if (dto.Command?.Id > 0)
                    item.Command = new SheduleCommandManager().Get(dto.Command.Id);
            }
            else
           if (dto.CommandId != null)
            {
                if (dto.CommandId > 0)
                    item.Command = new SheduleCommandManager().Get((int)dto.CommandId);
            }

            item.StartDateTime = dto.StartDateTime;

            return item;
        }
    }
}
