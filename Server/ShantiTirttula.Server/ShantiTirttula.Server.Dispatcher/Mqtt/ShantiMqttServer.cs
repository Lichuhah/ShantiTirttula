using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;
using MQTTnet.Formatter;
using MQTTnet.Packets;
using MQTTnet.Server;

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
        private int port = 707;
        private ShantiMqttServer()
        {
            CreateServer();
            CreateSubscriber();
            CreatePublisher();
        }

        private void CreateServer()
        {
            if (mqttServer != null)
            {
                return;
            }

            var options = new MqttServerOptionsBuilder()
                                    // set endpoint to localhost
                                    .WithDefaultEndpoint()
                                    // port used will be 707
                                    .WithDefaultEndpointPort(port)
                                    .Build();
            //options.EnablePersistentSessions = true;
            mqttServer = new MqttFactory().CreateMqttServer(options);

            try
            {
                mqttServer.StartAsync().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                mqttServer.StopAsync();
                mqttServer = null;
            }
        }

        public void CreateSubscriber()
        {
            var options = new ManagedMqttClientOptionsBuilder().WithAutoReconnectDelay(TimeSpan.FromSeconds(5))
           .WithClientOptions(new MqttClientOptionsBuilder().WithClientId("DispatcherSubscriber").WithTcpServer("localhost", port).Build()).Build();

            managedMqttClientSubscriber = new MqttFactory().CreateManagedMqttClient();
            managedMqttClientSubscriber.ApplicationMessageReceivedAsync += HandleReceivedApplicationMessage;
            var mqttFilter = new MqttTopicFilterBuilder().WithTopic("test").Build();
            managedMqttClientSubscriber.SubscribeAsync(new List<MqttTopicFilter> { mqttFilter });
            managedMqttClientSubscriber.StartAsync(options);
        }

        private static Task OnPublisherConnected(MqttClientConnectedEventArgs con)
        {
            return Task.CompletedTask;
        }

        private static Task OnPublisherDisconnected(MqttClientDisconnectedEventArgs _)
        {
            return Task.CompletedTask;
        }
        private Task HandleReceivedApplicationMessage(MqttApplicationMessageReceivedEventArgs eventArgs)
        {
            MqttHelper.NewMessage(eventArgs.ApplicationMessage);
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
                ProtocolVersion = MqttProtocolVersion.V500,
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

            managedMqttClientPublisher = mqttFactory.CreateManagedMqttClient();
            managedMqttClientPublisher.ApplicationMessageReceivedAsync += HandleReceivedApplicationMessage;
            managedMqttClientPublisher.ConnectedAsync += OnPublisherConnected;
            managedMqttClientPublisher.DisconnectedAsync += OnPublisherDisconnected;

            managedMqttClientPublisher.StartAsync(
                new ManagedMqttClientOptions
                {
                    ClientOptions = options
                });
        }

        public void SendMessage(string topic, string payload)
        {
            try
            {
                var message = new MqttApplicationMessageBuilder()
                    .WithTopic(topic).WithPayload(payload).Build();

                if (managedMqttClientPublisher != null)
                {
                    managedMqttClientPublisher.EnqueueAsync(message);
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
