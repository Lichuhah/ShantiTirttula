#include <ArduinoJson.h>

void ExecuteCommands(String command){
  StaticJsonDocument<200> doc;
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
      int value = repo["Value"].as<int>();
      bool isPWM = repo["IsPwm"].as<bool>();
      Serial.println(isPWM);
      Serial.println(value);
      Serial.println(pin);
      if(isPWM){
        analogWrite(pin, value);
      } else {
        if(value==1){ digitalWrite(pin, HIGH); }
        else { digitalWrite(pin, LOW); }
      } 
    }
  }
}
