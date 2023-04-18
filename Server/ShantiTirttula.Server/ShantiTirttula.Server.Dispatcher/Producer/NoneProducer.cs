using ShantiTirttula.Server.Dispatcher.Models;
using ShantiTirttula.Server.Dispatcher.Sessions;

namespace ShantiTirttula.Server.Dispatcher.Producer
{
    public class NoneProducer : CommandProducer
    {
        public override void Generate(Session session)
        {
            return;
        }

        public override void LoadDataForSession(string token)
        {
            return;
        }

        public override string GetData()
        {
            return "Authonomy work";
        }
    }
}
