namespace ShantiTirttula.Domain.Models
{
    public interface IUser : IEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
