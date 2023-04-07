#include <ArduinoJson.h>

StaticJsonDocument<200> doc;

void ClearData(String data){
  sensorValues[atoi(data.c_str())] = 0;
}

void ExecuteCommands(String command){
  DeserializationError error = deserializeJson(doc, command);

  // Test if parsing succeeds.
  if (error) {
    //Serial.println("fff");
    //Serial.print(F("deserializeJson() failed: "));
    //Serial.println(error.f_str());
    return;
  } else {
    JsonArray arr = doc.as<JsonArray>();
    for (JsonObject repo : arr) {
      int pin = repo["Pin"].as<int>();
      int value = repo["Value"].as<int>();
      bool isPWM = repo["IsPwm"].as<bool>();
      for(int i=0; i<2; i++){
        if(devices[i]==pin){
          devicesValues[i]=value;
        }
      }
      if(isPWM){
        ledcWrite(pin, value);
      } else {
        if(value==1){ digitalWrite(pin, HIGH); }
        else { digitalWrite(pin, LOW); }
      }
    }
  }
}
