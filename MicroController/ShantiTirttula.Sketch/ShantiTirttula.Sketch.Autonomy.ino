void LoadAutonomy(){
  String autoconfig = LoadFromFile("/autonomy.config");
  Serial.println(autoconfig);
  if(autoconfig == ""){
    AutonomyDoc.clear();
  }
  DeserializationError error = deserializeJson(AutonomyDoc, autoconfig);
   
  if (error) {
    Serial.print(F("deserializeJson() failed: "));
    Serial.println(error.f_str());
    AutonomyDoc.clear();
    return;
  }
}

void WriteAutonomy(String newConfig){
  Serial.println(newConfig);
  WriteToFile("/autonomy.config", newConfig);
}

void AutonomyWork(){
  Serial.println("autonomywork");
  JsonArray arr = AutonomyDoc.as<JsonArray>();
  for (JsonObject repo : arr) {
    if(repo["Type"].as<bool>() == 1){
      CheckTrigger1(repo);
    } 
    if(repo["Type"].as<bool>() == 2){
      CheckTrigger2(repo);
    } 
  }
}

void CheckTrigger1(JsonObject trigger){
  for(int i=0; i<sensorCount; i++){
    if(sensors[i] == trigger["SensorNumber"].as<int>()){
      if(sensorValues[i] > trigger["TriggerValue"].as<int>()){
        ExecuteCommand(trigger["Command"].as<String>());
      }
    }
  }
}

void CheckTrigger2(JsonObject trigger){
   for(int i=0; i<sensorCount; i++){
    if(sensors[i] == trigger["SensorNumber"].as<int>()){
      if(sensorValues[i] < trigger["TriggerValue"].as<int>()){
        ExecuteCommand(trigger["Command"].as<String>());
      }
    }
  }
}
