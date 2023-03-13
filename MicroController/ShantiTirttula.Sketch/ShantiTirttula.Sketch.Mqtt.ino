#include <PubSubClient.h>
WiFiClient espClient;   
PubSubClient client(espClient);
const char* mqtt_server = "130.193.34.231";
const int mqtt_port = 8002;

bool MQTTinit(){
  client.setServer(mqtt_server, mqtt_port);
  client.setCallback(callback);
  if (client.connect("ESP8266"))
    {
      client.subscribe("answer");
      client.subscribe(key.c_str());
      Serial.println("connected");
      return true;
    }
    else
    {
      Serial.print("failed with state ");
      Serial.println(client.state());
      return false;
    }
}

void reconnect() {
  while (!client.connected()) {
   if (client.connect("ESP8266"))
    {
      client.subscribe("answer");
      client.subscribe(key.c_str());
      Serial.println("connected");
    }
    else
    {
      Serial.print("failed with state ");
      Serial.println(client.state());
    }
  }
}

bool SendData(int sensors[], int values[]){
  if (!client.connected()) {
    reconnect();
  }
  client.publish("test", GetMqttMessage(sensors, values).c_str());
  client.loop();
  return true;
}

void callback(char* topic, byte* payload, unsigned int length) {
  Serial.print("Message arrived [");
  Serial.print(topic);
  Serial.print("] ");
  for (int i=0;i<length;i++) {
    Serial.print((char)payload[i]);
  }
  ExecuteCommands(String((char *)payload));
  Serial.println();
}
