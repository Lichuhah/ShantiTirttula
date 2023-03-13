#include <ESP8266WiFi.h>      

bool IsWiFiConnect = false;
bool IsMqttConnect = false;
int sensors[1] = {1};
int sensorValues[1] = {0};

void setup() {
  delay(1000);
  Serial.begin(115200);
  pinMode(A0, INPUT);
  Serial.println("Start 1-WIFI");
  //Запускаем WIFI
  IsWiFiConnect = WIFIinit();
  IsMqttConnect = MQTTinit();
}

void loop() {
  if(IsWiFiConnect){
    ReadData(A0);
    Serial.println(GetSensorJson(sensors, sensorValues));
  }
  delay(1000);
}
