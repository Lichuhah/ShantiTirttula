void ReadData(){
  sensorValues[0]=ReadSensorByPin(35);
  sensorValues[1]=ReadSensorByPin(32);
}

int ReadSensorByPin(int pin){
  int value = analogRead(pin);
  //Serial.println(value);
  return value;
}
