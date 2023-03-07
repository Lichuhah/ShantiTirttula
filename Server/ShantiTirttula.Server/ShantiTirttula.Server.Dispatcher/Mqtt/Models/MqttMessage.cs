﻿using ShantiTirttula.Server.Dispatcher.Models;

namespace ShantiTirttula.Server.Dispatcher.Mqtt.Models
{
    public class MqttMessage
    {
        public MqttHeader Headers { get; set; }
        public List<McSensorData> Data {get; set;}
    }
}