using Microsoft.AspNetCore.Mvc;
using MQTTnet;
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
        //public static void NewMessage(MqttApplicationMessageInterceptorContext context)
        //{
        //    var payload = context.ApplicationMessage?.Payload == null ? null : Encoding.UTF8.GetString(context.ApplicationMessage?.Payload);
        //    var message = JsonConvert.DeserializeObject<MqttMessage>(payload);
        //    //Session session = SessionList.GetList().GetSession(new McData { Mac = message.Headers.MAC, Key = message.Headers.Key });
        //    //session.AddSensorsData(message.Data);
        //    //if (session.Commands.Any())
        //    //{
        //        SendCommand();
        //    //    session.Commands.Clear();
        //    //}
        //}

        //private static void SendCommand(Session session)
        //{
        //    ShantiMqttServer mqttServer = ShantiMqttServer.GetServer();
        //    mqttServer.SendMessage("/"+session.Mc.Key, JsonConvert.SerializeObject(session.Commands));
        //}
        //private static void SendCommand()
        //{
        //    ShantiMqttServer mqttServer = ShantiMqttServer.GetServer();
        //    mqttServer.SendMessage("/", "fafawfwafa");
        //}
    }

}
