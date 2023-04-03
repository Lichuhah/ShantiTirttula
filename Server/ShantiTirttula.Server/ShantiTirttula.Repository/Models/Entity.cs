using ShantiTirttula.Domain.Models;

namespace ShantiTirttula.Repository.Models
{
    /// <summary>
    ///     <para>Базовый класс NHibernate</para>
    ///     <see cref="EntityMapping{T}" />
    /// </summary>
    public class Entity : IEntity
    {
        public virtual int Id { get; set; }
    }
}
