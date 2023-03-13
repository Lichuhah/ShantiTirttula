#include "LittleFS.h" 

String LoadFromFile(String file_name) {
  LittleFS.begin();
  String result = "";
  
  File this_file = LittleFS.open(file_name, "r");
  if (!this_file) { // failed to open the file, retrn empty result
    return result;
  }
  while (this_file.available()) {
      result += (char)this_file.read();
  }
  
  this_file.close();
  return result;
}

bool WriteToFile(String file_name, String contents) {  
  File this_file = LittleFS.open(file_name, "w");
  if (!this_file) { // failed to open the file, return false
    Serial.print("error open");
    return false;
  }
  int bytesWritten = this_file.print(contents);
 
  if (bytesWritten == 0) { // write failed
      return false;
  }
   
  this_file.close();
  return true;
}
