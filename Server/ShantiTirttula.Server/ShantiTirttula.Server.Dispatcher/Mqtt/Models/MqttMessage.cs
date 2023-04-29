using ShantiTirttula.Domain.Dto.Models;
using ShantiTirttula.Server.Dispatcher.Models;

namespace ShantiTirttula.Server.Dispatcher.Mqtt.Models
{
    public class MqttMessage
    {
        public MqttHeader Headers { get; set; }
        public List<SensorDataDto> Data {get; set;}
        public List<McDeviceValues> Devices { get; set; }
    }
}
