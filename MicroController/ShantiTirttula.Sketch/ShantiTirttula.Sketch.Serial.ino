StaticJsonDocument<200> serialDoc;

void ReadSerial(){
  if (Serial.available() > 0) {
    String message = Serial.readString();
    DeserializationError error = deserializeJson(serialDoc, message);
   
    if (error) {
      Serial.print(F("deserializeJson() failed: "));
      Serial.println(error.f_str());
      return;
    } else {
      String command = serialDoc["command"].as<String>();
      ExecuteSerialCommand(command);
    }
  }
}

void ExecuteSerialCommand(String command){
  if(command == "getwificonfig") {
    Serial.print(GetWifiConfigJson());
    return;
  }
  if(command == "setwificonfig") {
    WriteNewConfig();
    SetWiFi(serialDoc["data"].as<String>());
    return;
  }
  if(command == "setkeyconfig"){
    SetKey(serialDoc["data"].as<String>());
  }
  serialDoc.clear();
  Serial.print("Wrong command");
}

void SetWiFi(String data){
  deserializeJson(serialDoc, data);
  wifi_ssid = serialDoc["ssid"].as<String>();
  wifi_password = serialDoc["password"].as<String>();
  serialDoc.clear();
  WriteConfig();
  IsWiFiConnect = WIFIinit();
  Serial.print(GetWifiConfigJson());
}

void SetKey(String data){
  deserializeJson(serialDoc, data);
  key = serialDoc["key"].as<String>();
  serialDoc.clear();
  WriteConfig();
  IsWiFiConnect = WIFIinit();
  Serial.print(GetWifiConfigJson());
}
