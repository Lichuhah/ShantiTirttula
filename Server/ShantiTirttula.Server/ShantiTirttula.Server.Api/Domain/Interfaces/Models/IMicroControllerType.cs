namespace ShantiTirttula.Server.Api.Domain.Interfaces.Models
{
    public interface IMicroControllerType : IEntity
    {
        public string Name { get; set; }
        public IList<IMicroController> Controllers { get; set; }
    }
}
