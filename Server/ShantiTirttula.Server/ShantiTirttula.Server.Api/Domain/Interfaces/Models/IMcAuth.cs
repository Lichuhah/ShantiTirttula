namespace ShantiTirttula.Server.Api.Domain.Interfaces.Models
{
    public interface IMcAuth : IEntity
    {
        public string Mac { get; set; }
        public string Key { get; set; }
        public IUser User { get; set; }
    }
}
