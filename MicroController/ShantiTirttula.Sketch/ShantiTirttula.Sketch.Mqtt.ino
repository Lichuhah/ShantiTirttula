#include <PubSubClient.h>

WiFiClient espClient;
const char* mqtt_server = "130.193.34.231";
const int mqtt_port = 8002;

PubSubClient client(espClient);

bool MQTTinit(){
  client.setServer(mqtt_server, mqtt_port);
  //client.setCallback(MQTTcallback);
  
  if (client.connect("ESP8266"))
    {
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
