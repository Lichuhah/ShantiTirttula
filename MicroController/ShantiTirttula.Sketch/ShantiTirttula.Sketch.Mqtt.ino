#include <PubSubClient.h>
WiFiClient espClient;   
PubSubClient client(espClient);
const char* mqtt_server = "130.193.34.231";
const int mqtt_port = 9002;

bool MQTTinit(){
  Serial.println("a");
  client.setServer(mqtt_server, mqtt_port);
  client.setCallback(callback);
  Serial.println("b");
  if (client.connect("ESP8266"))
    {
      //client.subscribe("answer");
      Serial.println("c");
      client.subscribe(key.c_str());
      client.subscribe((key+"_cm").c_str());
      client.subscribe((key+"_cl").c_str());
      client.subscribe((key+"_f").c_str());
      Serial.println("connected");
      triesConnect = 0;
      isConnected = true;
      return true;
    }
    else
    {
      Serial.print("failed with state ");
      Serial.println(client.state());
      triesConnect++;
      return false;
    }
}

void reconnect() {
  while (!client.connected()) {
   if (client.connect("ESP8266"))
    {
      client.subscribe("answer");
      client.subscribe(key.c_str());
      client.subscribe((key+"_cm").c_str());
      client.subscribe((key+"_cl").c_str());
      client.subscribe((key+"_cf").c_str());
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
    IsMqttConnect = false;
    return false;
  } else {
    client.publish("test", GetMqttMessage().c_str());
    delay(100);
    client.loop();
    delay(100);
    return true;
  }
}

void callback(char* topic, byte* payload, unsigned int length) {
  delay(100);
  if((key+"_cm").equals(String(topic))){
    ExecuteCommands(String((char *)payload));
  } else
  if((key+"_cl").equals(String(topic))){
    ClearData(String((char*) payload));
  } else 
  if((key+"_f").equals(String(topic))){
    WriteAutonomy(String((char *)payload));
    LoadAutonomy();
  }
  delay(100);
  return;
  //Serial.println();
}
