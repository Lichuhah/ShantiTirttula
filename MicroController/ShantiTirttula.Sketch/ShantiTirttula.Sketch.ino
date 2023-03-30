#include <ESP8266WiFi.h>   

bool IsWiFiConnect = false;
bool IsMqttConnect = false;
int sensors[1] = {1};
int sensorValues[1] = {0};
double devicesValues[1]={0};
String key;
String mac;
String wifi_ssid     = ""; // Для хранения SSID
String wifi_password = ""; // Для хранения пароля сети

void setup() {
  delay(1000);
  Serial.begin(115200);
  mac = WiFi.macAddress();
  pinMode(A0, INPUT);
  pinMode(5, OUTPUT);
  //Serial.println("Start 1-WIFI");
  //Запускаем WIFI
  LoadConfig();
  IsWiFiConnect = WIFIinit();
  IsMqttConnect = MQTTinit();
}

void loop() {
  Serial.println("work0");
  Serial.println(IsWiFiConnect);
  Serial.println(IsMqttConnect);
  ReadSerial();
  if(IsWiFiConnect){
    if(IsMqttConnect){
      ReadData(A0);
      SendData(sensors, sensorValues);
    } else {
      IsMqttConnect = MQTTinit();
    }
  } else {
    IsWiFiConnect = WIFIinit();
  }
  delay(1000);
}
