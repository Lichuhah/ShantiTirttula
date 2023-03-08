using Microsoft.Extensions.Options;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;
using MQTTnet.Formatter;
using MQTTnet.Packets;
using MQTTnet.Protocol;
using MQTTnet.Server;
using Newtonsoft.Json;
using ShantiTirttula.Server.Dispatcher.Sessions;
using System.Text;

namespace ShantiTirttula.Server.Dispatcher.Mqtt
{
    public class ShantiMqttServer
    {
        private static ShantiMqttServer instance;
        /// <summary>
        /// The managed publisher client.
        /// </summary>
        private IManagedMqttClient? managedMqttClientPublisher;

        /// <summary>
        /// The managed subscriber client.
        /// </summary>
        private IManagedMqttClient? managedMqttClientSubscriber;

        /// <summary>
        /// The MQTT server.
        /// </summary>
        private MqttServer? mqttServer;

        /// <summary>
        /// The port.
        /// </summary>
        private int port = 773;
        private ShantiMqttServer()
        {
            CreateServer();
            CreateSubscriber();
            CreatePublisher();
        }

        private void CreateServer()
        {
            if (this.mqttServer != null)
            {
                return;
            }

            var options = new MqttServerOptions();
            options.DefaultEndpointOptions.Port = port;
            options.EnablePersistentSessions = true;
            this.mqttServer = new MqttFactory().CreateMqttServer(options);

            try
            {
                this.mqttServer.StartAsync();
            }
            catch (Exception ex)
            {
                this.mqttServer.StopAsync();
                this.mqttServer = null;
            }
        }
        public void CreateSubscriber()
        {
            var options = new ManagedMqttClientOptionsBuilder().WithAutoReconnectDelay(TimeSpan.FromSeconds(5))
           .WithClientOptions(new MqttClientOptionsBuilder().WithClientId("DispacherSubscriber").WithTcpServer("localhost", port).WithTls().Build()).Build();

            this.managedMqttClientSubscriber = new MqttFactory().CreateManagedMqttClient();
            this.managedMqttClientSubscriber.ApplicationMessageReceivedAsync += this.HandleReceivedApplicationMessage;
            var mqttFilter = new MqttTopicFilterBuilder().WithTopic("test").Build();
            this.managedMqttClientSubscriber.SubscribeAsync(new List<MqttTopicFilter> { mqttFilter });
            this.managedMqttClientSubscriber.StartAsync(options);
        }

        /// <summary>
        /// Handles the publisher connected event.
        /// </summary>
        private static Task OnPublisherConnected(MqttClientConnectedEventArgs _)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Handles the publisher disconnected event.
        /// </summary>
        private static Task OnPublisherDisconnected(MqttClientDisconnectedEventArgs _)
        {
            return Task.CompletedTask;
        }
        private Task HandleReceivedApplicationMessage(MqttApplicationMessageReceivedEventArgs eventArgs)
        {
            return Task.CompletedTask;
        }

        public void CreatePublisher()
        {
            var mqttFactory = new MqttFactory();

            var tlsOptions = new MqttClientTlsOptions
            {
                UseTls = false,
                IgnoreCertificateChainErrors = true,
                IgnoreCertificateRevocationErrors = true,
                AllowUntrustedCertificates = true
            };

            var options = new MqttClientOptions
            {
                ClientId = "DispatcherPublisher",
                ProtocolVersion = MqttProtocolVersion.V311,
                ChannelOptions = new MqttClientTcpOptions
                {
                    Server = "localhost",
                    Port = port,
                    TlsOptions = tlsOptions
                }
            };

            if (options.ChannelOptions == null)
            {
                throw new InvalidOperationException();
            }

            options.CleanSession = true;
            options.KeepAlivePeriod = TimeSpan.FromSeconds(5);

            this.managedMqttClientPublisher = mqttFactory.CreateManagedMqttClient();
            this.managedMqttClientPublisher.ApplicationMessageReceivedAsync += this.HandleReceivedApplicationMessage;
            this.managedMqttClientPublisher.ConnectedAsync += OnPublisherConnected;
            this.managedMqttClientPublisher.DisconnectedAsync += OnPublisherDisconnected;

            this.managedMqttClientPublisher.StartAsync(
                new ManagedMqttClientOptions
                {
                    ClientOptions = options
                });
        }

        public void SendMessage()
        {
            try
            {
                var payload = Encoding.UTF8.GetBytes("message from disp publisher");

                var message = new MqttApplicationMessageBuilder()
                    .WithTopic("test").WithPayload(payload).WithQualityOfServiceLevel(MqttQualityOfServiceLevel.AtLeastOnce).WithRetainFlag().Build();

                if (this.managedMqttClientPublisher != null)
                {
                    this.managedMqttClientPublisher.EnqueueAsync(message);
                }
            }
            catch (Exception ex)
            {
                var a = 5;
            }
        }
        public static ShantiMqttServer GetServer()
        {
            if (instance == null)
                instance = new ShantiMqttServer();
            return instance;
        }
    }
}
