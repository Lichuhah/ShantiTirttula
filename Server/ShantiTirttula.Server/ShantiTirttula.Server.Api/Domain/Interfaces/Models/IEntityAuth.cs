namespace ShantiTirttula.Server.Api.Domain.Interfaces.Models
{
    public interface IEntityAuth : IEntity
    {
        public IAuth Auth { get; }
    }
}
