using Microsoft.AspNetCore.Mvc;
using MQTTnet.Server;
using Newtonsoft.Json;
using ShantiTirttula.Server.Dispatcher.Models;
using ShantiTirttula.Server.Dispatcher.Mqtt.Models;
using ShantiTirttula.Server.Dispatcher.Sessions;
using System.Security.Cryptography;
using System.Text;

namespace ShantiTirttula.Server.Dispatcher.Mqtt
{
    public static class MqttHelper
    {
        public static void NewMessage(MqttApplicationMessageInterceptorContext context)
        {
            var payload = context.ApplicationMessage?.Payload == null ? null : Encoding.UTF8.GetString(context.ApplicationMessage?.Payload);
            var message = JsonConvert.DeserializeObject<MqttMessage>(payload);
            Session session = SessionList.GetList().GetSession(new McData { MAC = message.Headers.MAC });
            var v = "v";
        }
    }
}
