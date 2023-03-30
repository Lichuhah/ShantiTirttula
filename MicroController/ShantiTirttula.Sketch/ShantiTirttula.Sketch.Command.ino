#include <ArduinoJson.h>

StaticJsonDocument<200> doc;

void ExecuteCommands(String command){
  DeserializationError error = deserializeJson(doc, command);

  // Test if parsing succeeds.
  if (error) {
    Serial.print(F("deserializeJson() failed: "));
    Serial.println(error.f_str());
    return;
  } else {
    JsonArray arr = doc.as<JsonArray>();
    for (JsonObject repo : arr) {
      int pin = repo["Pin"].as<int>();
      int value = repo["Value"].as<double>();
      bool isPWM = repo["IsPwm"].as<bool>();
      devicesValues[1]=value;
      if(isPWM){
        analogWrite(pin, value);
      } else {
        if(value==1){ digitalWrite(pin, HIGH); }
        else { digitalWrite(pin, LOW); }
      }
    }
  }
}
