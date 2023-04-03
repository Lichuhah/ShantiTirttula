namespace ShantiTirttula.Server.Api.Domain.Interfaces.Models
{
    public interface IAuth : IEntity
    {
        public string Key { get; set; }
        public IUser User { get; set; }
        public IList<ITrigger> Triggers { get; set; }
        public IProduct Product { get; set; }
    }
}
