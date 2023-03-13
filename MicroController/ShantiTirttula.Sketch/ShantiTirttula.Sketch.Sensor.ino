void ReadData(int outPin){
  sensorValues[0]=ReadSensorByPin(A0);
}

int ReadSensorByPin(int pin){
  int value = analogRead(pin);
  //Serial.println(value);
  return value;
}
