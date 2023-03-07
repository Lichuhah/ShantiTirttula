namespace ShantiTirttula.Server.Api.Domain.Interfaces.Models
{
    public interface IMcAuth : IEntity
    {
        public string Key { get; set; }
        public IUser User { get; set; }
        public IList<ITrigger> Triggers { get; set; }
        public IController Controller { get; set; }
    }
}
