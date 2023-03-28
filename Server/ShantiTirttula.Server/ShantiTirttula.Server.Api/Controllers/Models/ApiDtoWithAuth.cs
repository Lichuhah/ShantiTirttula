using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Controllers.Models
{
    public class ApiDtoWithAuth<T> : ApiDto<T> where T : IEntity
    {
        public int AuthId { get; set; }
    }
}
