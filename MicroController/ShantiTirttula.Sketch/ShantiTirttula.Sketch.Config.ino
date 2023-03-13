void LoadConfig(){
  String config = LoadFromFile("/data.config");
  if(config == ""){
    WriteNewConfig();
    config = LoadFromFile("/data.config");
  }

   DeserializationError error = deserializeJson(doc, config);
   
  if (error) {
    Serial.print(F("deserializeJson() failed: "));
    Serial.println(error.f_str());
    doc.clear();
    return;
  } else {
    wifi_ssid = doc["wifi_ssid"].as<String>();
    wifi_password = doc["wifi_password"].as<String>();
    key = doc["key"].as<String>();
    doc.clear();
  }
}

void WriteNewConfig(){
  doc["wifi_ssid"]="";
  doc["wifi_password"]="";
  doc["key"]="";
  String jsonConfig; 
  serializeJson(doc, jsonConfig);
  doc.clear();
  WriteToFile("/data.config", jsonConfig);
}

void WriteConfig(){
  doc["wifi_ssid"]=wifi_ssid;
  doc["wifi_password"]=wifi_password;
  doc["key"]=key;
  String jsonConfig; 
  serializeJson(doc, jsonConfig);
  doc.clear();
  WriteToFile("/data.config", jsonConfig);
}
