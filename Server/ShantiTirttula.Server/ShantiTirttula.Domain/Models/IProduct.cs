namespace ShantiTirttula.Domain.Models
{
    public interface IProduct : IEntity
    {
        public string Mac { get; set; }
        public IMicroController Controller { get; set; }
    }
}
