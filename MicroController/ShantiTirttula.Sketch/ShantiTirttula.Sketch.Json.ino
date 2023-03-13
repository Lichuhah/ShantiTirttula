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
