using ShantiTirttula.Domain.Models;

namespace ShantiTirttula.Domain.Dto
{
    public class ApiDtoWithAuth<T> : ApiDto<T> where T : IEntityAuth
    {
        public int AuthId { get; set; }
    }
}
