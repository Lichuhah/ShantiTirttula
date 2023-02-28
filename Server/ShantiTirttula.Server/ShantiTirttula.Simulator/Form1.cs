using MQTTnet.Client;
using MQTTnet;
using Newtonsoft.Json;
using System;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client.Options;
using MQTTnet.Extensions.ManagedClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShantiTirttula.Simulator.Model;
using System.Net.Http;
using System.Text;
using System.Collections.Generic;

namespace ShantiTirttula.Simulator
{
    public partial class Form1 : Form
    {
        string Login = "admin";
        string Password = "admin";
        string Mac = "111111111111";
        string Key = "1EXN43Q8U77PHU1M";
        public Form1()
        {
            InitializeComponent();
        }
        public static void OnConnected(MqttClientConnectedEventArgs obj)
        {
            Console.WriteLine("Successfully connected.");
        }

        public static void OnConnectingFailed(ManagedProcessFailedEventArgs obj)
        {
            Console.WriteLine("Successfully connected.");
        }

        public static void OnDisconnected(MqttClientDisconnectedEventArgs obj)
        {
            Console.WriteLine("Successfully disconnected.");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Creates a new client
            MqttClientOptionsBuilder builder = new MqttClientOptionsBuilder()
                                                    .WithClientId("Dev.To")
                                                    .WithTcpServer("localhost", 707);

            // Create client options objects
            ManagedMqttClientOptions options = new ManagedMqttClientOptionsBuilder()
                                    .WithAutoReconnectDelay(TimeSpan.FromSeconds(60))
                                    .WithClientOptions(builder.Build())
                                    .Build();

            // Creates the client object
            IManagedMqttClient _mqttClient = new MqttFactory().CreateManagedMqttClient();

            // Set up handlers
            _mqttClient.ConnectedHandler = new MqttClientConnectedHandlerDelegate(OnConnected);
            _mqttClient.DisconnectedHandler = new MqttClientDisconnectedHandlerDelegate(OnDisconnected);
            _mqttClient.ConnectingFailedHandler = new ConnectingFailedHandlerDelegate(OnConnectingFailed);

            // Starts a connection with the Broker
            _mqttClient.StartAsync(options).GetAwaiter().GetResult();

            // Send a new message to the broker every second
            //while (true)
            //{
            Headers head = new Headers
            {
                MAC = this.Mac,
                Key = this.Key
                
            };
            List<SendDataExample> list = new List<SendDataExample>();
            list.Add(new SendDataExample
            {
                SensorId = 1,
                Value = 1
            });
                string json = JsonConvert.SerializeObject(new { Data = list, Headers = head, sent = DateTimeOffset.UtcNow });
                _mqttClient.PublishAsync("dev.to/topic/json", json);

                Task.Delay(1000).GetAwaiter().GetResult();
            //}

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.txt_mac.Text = this.Mac;
        }

        private void btn_key_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7125/api/key/get");
            McLoginData data = new McLoginData
            {
                Login = this.Login,
                Password = this.Password,
                Mac = this.Mac
            };
            request.Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.SendAsync(request).Result;
            this.Key = response.Content.ReadAsStringAsync().Result;
            this.txt_key.Text = this.Key;
        }
    }
}
