namespace ShantiTirttula.Server.Api.Domain.Interfaces.Models
{
    public interface IProduct : IEntity
    {
        public string Mac { get; set; }
        public IMicroController Controller { get; set; }
    }
}
