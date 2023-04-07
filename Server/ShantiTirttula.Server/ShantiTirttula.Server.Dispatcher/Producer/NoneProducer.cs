using ShantiTirttula.Server.Dispatcher.Models;

namespace ShantiTirttula.Server.Dispatcher.Producer
{
    public class NoneProducer : CommandProducer
    {
        public override void Generate(List<McSensorData> datas)
        {
            return;
        }

        public override void LoadDataForSession(string token)
        {
            return;
        }
    }
}
