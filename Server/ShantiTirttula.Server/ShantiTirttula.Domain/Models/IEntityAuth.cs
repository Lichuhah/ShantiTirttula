namespace ShantiTirttula.Domain.Models
{
    public interface IEntityAuth : IEntity
    {
        public abstract IAuth Auth { get; }
    }
}
