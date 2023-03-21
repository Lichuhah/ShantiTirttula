String GetSensorJson(int sensors[], int values[]){
  int leng = sizeof(sensors)/sizeof(int);
  String json = "[";
  for(int i=0; i<leng; i++){
    json += "{";
    json += "\"Value\":\"";
    json += values[i];
    json += "\",\"SensorId\":\"";
    json += sensors[i];
    json += "\"}";
    if(i!=leng-1) json+=",";
  }
  json += "]";
  return json;
}

String GetHeadersJson(){
  String json = "{";
  json += "\"Mac\":\"";
  json += mac;
  json += "\",\"Key\":\"";
  json += key;
  json += "\"}";
  return json;
}

String GetMqttMessage(int sensors[], int values[]){
  String json = "{";
  json += "\"Headers\":";
  json += GetHeadersJson();
  json += ",\"Data\":";
  json += GetSensorJson(sensors, values);
  json += "}";
  Serial.println(json);
  return json;
}

String GetWifiConfigJson(){
  doc["ssid"]=wifi_ssid;
  doc["password"]=wifi_password;
  doc["isconnect"]=IsWiFiConnect;
  doc["mac"]=mac;
  doc["key"]=key;
  String jsonConfig; 
  serializeJson(doc, jsonConfig);
  doc.clear();
  return jsonConfig;
}
