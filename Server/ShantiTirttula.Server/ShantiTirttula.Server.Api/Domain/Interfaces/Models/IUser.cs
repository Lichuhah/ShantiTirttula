namespace ShantiTirttula.Server.Api.Domain.Interfaces.Models
{
    public interface IUser : IEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
