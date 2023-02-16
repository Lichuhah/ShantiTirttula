using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Models
{
    /// <summary>
    ///     <para>Базовый класс NHibernate</para>
    ///     <see cref="EntityMapping{T}" />
    /// </summary>
    public class Entity : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Test { get; set; }
    }
}
