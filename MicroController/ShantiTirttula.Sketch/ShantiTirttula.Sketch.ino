#include <WiFi.h>   
#include <ArduinoJson.h>


bool IsWiFiConnect = false;
bool IsMqttConnect = false;
int sensorCount = 3;
int sensors[3] = {1,2,3};
int sensorValues[3] = {0,0,0};
int deviceCount = 2;
int devices[2] ={4, 16};
int devicesValues[2]={0,0};
String key;
String mac;
String wifi_ssid     = ""; // Для хранения SSID
String wifi_password = ""; // Для хранения пароля сети
int triesConnect = 0;
bool isConnected = true;
StaticJsonDocument<512> AutonomyDoc;

void setup() {
  delay(1000);
  Serial.begin(115200);
  mac = WiFi.macAddress();
  pinMode(35, INPUT);
  pinMode(32, INPUT);
  pinMode(34, INPUT);
  attachInterrupt(34,ReadWater,RISING);
  sei();
  pinMode(4, OUTPUT);
  pinMode(16,OUTPUT);
  //Serial.println("Start 1-WIFI");
  //Запускаем WIFI
  LoadConfig();
  LoadAutonomy();
  IsWiFiConnect = WIFIinit();
  IsMqttConnect = MQTTinit();
}

void networkLoop(){
  if(IsWiFiConnect){
    if(IsMqttConnect){
      ReadData();
      //Serial.println(GetMqttMessage().c_str());
      SendData();
    } else {
      IsMqttConnect = MQTTinit();
      if(triesConnect>10)  { 
        isConnected = false;
        triesConnect = 0;
      }
    }
  } else {
    IsWiFiConnect = WIFIinit();
    if(triesConnect>10) { 
      isConnected = false;
      triesConnect = 0;
    }
  }
}

void autonomyLoop(){
  triesConnect++;
  if(triesConnect > 10){
    triesConnect = 0;
    isConnected = true;
  } else {
    ReadData();
    AutonomyWork();
  }
}

void loop() {
   //Serial.println("work0");
   //Serial.println(IsWiFiConnect);
   //Serial.println(IsMqttConnect);
   ReadSerial();
   Serial.println("SERIAL");
   if(isConnected){
      networkLoop();
   } else {
      autonomyLoop();
   }
  delay(2000);
  
}
