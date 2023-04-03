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
        public static void NewMessage(MqttApplicationMessage context)
        {
            var payload = context?.Payload == null ? null : Encoding.UTF8.GetString(context?.Payload);
            ShantiMqttServer mqttServer = ShantiMqttServer.GetServer();
            try
            {
                var message = JsonConvert.DeserializeObject<MqttMessage>(payload);
                Session session = SessionList.GetList().GetSession(new McData { Mac = message.Headers.Mac, Key = message.Headers.Key });
                if (!session.IsBusy)
                {
                    session.SetDeviceValues(message.Devices);
                    session.AddSensorsData(message.Data);
                    if (session.Commands.Any())
                    {
                        SendCommand(session);
                        //session.SaveCommandsLog();
                    }
                }
            } catch (Exception ex)
            {
                mqttServer.SendMessage("answer", ex.Message);
            }
        }

        private static void SendCommand(Session session)
        {
            ShantiMqttServer mqttServer = ShantiMqttServer.GetServer();
            mqttServer.SendMessage(session.Mc.Key, JsonConvert.SerializeObject(session.Commands));
        }

        public static void SendError(string error)
        {
            ShantiMqttServer mqttServer = ShantiMqttServer.GetServer();
            mqttServer.SendMessage("answer", error);
        }
    }

}
