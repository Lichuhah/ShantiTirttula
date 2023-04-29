using ShantiTirttula.Domain.Dto;
using ShantiTirttula.Domain.Dto.Models;
using ShantiTirttula.Domain.Managers.Managment.Shedules;
using ShantiTirttula.Domain.Models.Managment.Shedules;
using ShantiTirttula.Repository.Models.Managment.Shedules;

namespace ShantiTirttula.Repository.Managers.Managment.Shedules
{
    public class SheduleManager : EntityManager<IShedule>, ISheduleManager
    {
        public SheduleManager() : base()
        {

        }

        public override SheduleDto ConvertToDto(IShedule entity)
        {
            SheduleDto dto = new SheduleDto
            {
                Id = entity.Id,
                Period = entity.Period,
                StartTime = DateTime.SpecifyKind(entity.StartTime, DateTimeKind.Utc),
                EndTime = DateTime.SpecifyKind(entity.StartTime, DateTimeKind.Utc),
                StartCommandId = entity.StartCommand.Id,
                EndCommandId = entity.EndCommand.Id,
                AuthId = entity.Auth.Id
            };
            return dto;
        }

        public override IShedule ConvertFromDto(ApiDto<IShedule> data)
        {
            IShedule item;
            if (data.Id > 0)
                item = Get(data.Id);
            else
                item = new Shedule();

            SheduleDto dto = (SheduleDto)data;
            if (dto.AuthId > 0)
            {
                item.Auth = new AuthManager().Get(dto.AuthId);
            }
            if (dto.StartCommandId > 0)
            {
                item.StartCommand = new SheduleCommandManager().Get(dto.StartCommandId);
            }
            if (dto.EndCommandId > 0)
            {
                item.EndCommand = new SheduleCommandManager().Get(dto.EndCommandId);
            }
            item.StartTime = dto.StartTime;
            item.EndTime = dto.EndTime;
            item.Period = dto.Period;
            item.LastExecutionTime = DateTime.UtcNow;

            return item;
        }
    }
}
