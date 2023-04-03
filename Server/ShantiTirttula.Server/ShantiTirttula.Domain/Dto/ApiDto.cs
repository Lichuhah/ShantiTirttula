using ShantiTirttula.Domain.Models;

namespace ShantiTirttula.Domain.Dto
{
    public class ApiDto<T> where T : IEntity
    {
        public int Id { get; set; }
    }
}
