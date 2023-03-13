#include <ESP8266WiFi.h>   

bool IsWiFiConnect = false;
bool IsMqttConnect = false;
int sensors[1] = {1};
int sensorValues[1] = {0};
String key = "F0YVLRB7M091IJGX";
String mac = "111111111111";

void setup() {
  delay(1000);
  Serial.begin(115200);
  pinMode(A0, INPUT);
  pinMode(5, OUTPUT);
  Serial.println("Start 1-WIFI");
  //Запускаем WIFI
  IsWiFiConnect = WIFIinit();
  IsMqttConnect = MQTTinit();
}

void loop() {
  if(IsWiFiConnect){
    ReadData(A0);
    SendData(sensors, sensorValues);
  }
  delay(1000);
}
