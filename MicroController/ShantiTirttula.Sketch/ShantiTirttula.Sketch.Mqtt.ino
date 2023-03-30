#include <PubSubClient.h>
WiFiClient espClient;   
PubSubClient client(espClient);
const char* mqtt_server = "130.193.34.231";
const int mqtt_port = 9002;

bool MQTTinit(){
  client.setServer(mqtt_server, mqtt_port);
  client.setCallback(callback);
  if (client.connect("ESP8266"))
    {
      //client.subscribe("answer");
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

bool SendData(){
  if (!client.connected()) {
    reconnect();
  }
  client.publish("test", GetMqttMessage().c_str());
  delay(100);
  client.loop();
  delay(100);
  return true;
}

void callback(char* topic, byte* payload, unsigned int length) {
  //Serial.print("Message arrived [");
  //Serial.print(topic);
  //Serial.print("] ");
  //for (int i=0;i<length;i++) {
    //Serial.print((char)payload[i]);
  //}
  delay(100);
  ExecuteCommands(String((char *)payload));
  delay(100);
  return;
  //Serial.println();
}
