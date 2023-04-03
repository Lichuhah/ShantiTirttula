namespace ShantiTirttula.Domain.Models
{
    public interface IEntityAuth : IEntity
    {
        public IAuth Auth { get; }
    }
}
