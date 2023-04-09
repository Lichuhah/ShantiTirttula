String GetSensorJson(){
  String json = "[";
  for(int i=0; i<sensorCount; i++){
    json += "{";
    json += "\"Value\":";
    json += sensorValues[i];
    json += ",\"SensorId\":";
    json += sensors[i];
    json += "}";
    if(i!=sensorCount-1) json+=",";
  }
  json += "]";
  return json;
}

String GetDeviceJson(){
  String json = "[";
  for(int i=0; i<deviceCount; i++){
    json += "{";
    json += "\"Value\":";
    json += devicesValues[i];
    json += ",\"Pin\":";
    json += devices[i];
    json += "}";
    if(i!=deviceCount-1) json+=",";
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

String GetMqttMessage(){
  String json = "{";
  json += "\"Headers\":";
  json += GetHeadersJson();
  json += ",\"Data\":";
  json += GetSensorJson();
  json += ",\"Devices\":";
  json += GetDeviceJson();
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
