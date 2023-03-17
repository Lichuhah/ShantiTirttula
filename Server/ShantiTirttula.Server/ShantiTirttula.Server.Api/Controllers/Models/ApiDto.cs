using ShantiTirttula.Server.Api.Domain.Implementations.Models;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Controllers.Models
{
    public class ApiDto<T> where T : IEntity
    {
       public int Id { get; set; }
    }
}
