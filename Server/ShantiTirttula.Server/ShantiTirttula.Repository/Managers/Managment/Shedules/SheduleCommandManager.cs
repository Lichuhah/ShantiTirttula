using ShantiTirttula.Domain.Dto.Models;
using ShantiTirttula.Domain.Dto;
using ShantiTirttula.Domain.Managers.Managment.Shedules;
using ShantiTirttula.Domain.Models.Managment.Shedules;
using ShantiTirttula.Repository.Models.Managment.Shedules;

namespace ShantiTirttula.Repository.Managers.Managment.Shedules
{
    public class SheduleCommandManager : EntityManager<ISheduleCommand>, ISheduleCommandManager
    {
        public SheduleCommandManager() : base()
        {

        }

        public override CommandDto ConvertToDto(ISheduleCommand entity)
        {
            CommandDto dto = new CommandDto();
            dto.Id = entity.Id;
            dto.Value = entity.Value;
            dto.IsPwm = entity.Device.IsAnalog;
            dto.Pin = entity.Device.Pin;
            return dto;
        }

        public override ISheduleCommand ConvertFromDto(ApiDto<ISheduleCommand> data)
        {
            ISheduleCommand item;
            if (data.Id > 0)
                item = Get(data.Id);
            else
                item = new SheduleCommand();

            CommandDto dto = (CommandDto)data;

            return item;
        }
    }
}
