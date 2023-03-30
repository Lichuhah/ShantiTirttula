#include <WiFi.h>   

bool IsWiFiConnect = false;
bool IsMqttConnect = false;
int sensors[2] = {1,2};
int sensorValues[2] = {0,0};
int devices[2] ={4, 16};
int devicesValues[2]={0,0};
String key;
String mac;
String wifi_ssid     = ""; // Для хранения SSID
String wifi_password = ""; // Для хранения пароля сети

void setup() {
  delay(1000);
  Serial.begin(115200);
  mac = WiFi.macAddress();
  pinMode(35, INPUT);
  pinMode(32, INPUT);
  pinMode(4, OUTPUT);
  pinMode(16, OUTPUT);
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
      ReadData();
      SendData();
    } else {
      IsMqttConnect = MQTTinit();
    }
  } else {
    IsWiFiConnect = WIFIinit();
  }
  delay(1000);
  
}
