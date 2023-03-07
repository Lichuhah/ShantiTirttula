namespace ShantiTirttula.Server.Api.Domain.Interfaces.Models
{
    public interface IControllerType : IEntity
    {
        public string Name { get; set; }
        public IList<IController> Controllers { get; set; }
    }
}
