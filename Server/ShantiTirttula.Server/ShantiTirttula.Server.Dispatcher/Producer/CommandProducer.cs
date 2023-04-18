using ShantiTirttula.Domain.Dto.Models;
using ShantiTirttula.Server.Dispatcher.Models;
using ShantiTirttula.Server.Dispatcher.Sessions;

namespace ShantiTirttula.Server.Dispatcher.Producer
{
    public abstract class CommandProducer
    {
        public CommandProducer() { this.Commands = new List<CommandDto>(); }
        public List<CommandDto> Commands { get; set; }
        public abstract void LoadDataForSession(string token);
        public abstract void Generate(Session session);
        public abstract string GetData();
    }
}
