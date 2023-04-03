namespace ShantiTirttula.Domain.Models
{
    public interface IMicroControllerType : IEntity
    {
        public string Name { get; set; }
        public IList<IMicroController> Controllers { get; set; }
    }
}
