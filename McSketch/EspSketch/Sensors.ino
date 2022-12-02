String readSensors(){
  if(apiIsConnected){
    byte tries = 11;
    Serial.println(-1);
    while(--tries && true){
      int signal = Serial.parseInt();
      if(signal==-1){
        float light = Serial.parseFloat();
        float temp = Serial.parseFloat();
        //float wet = Serial.parseFloat();
        int sensors[2] = {1,2};
        float datas[2] = {temp, light};
        return sendSensorValue("/sensor/send",sensors,datas);
      }
    }
  }
}
