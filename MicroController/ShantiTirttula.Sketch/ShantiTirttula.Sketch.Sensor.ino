void ReadData(){
  ReadLight();
  ReadTemp();
  //ReadWet();
}

void ReadTemp(){
  sensorValues[1]=ReadSensorByPin(32);
}

void ReadLight(){
  sensorValues[0]=ReadSensorByPin(35);
}

void ReadWet(){
  sensorValues[2]=analogRead(34);
}

void ReadWater(){
  sensorValues[2]=sensorValues[2]+1;
}

int ReadSensorByPin(int pin){
  int value = analogRead(pin);
  //Serial.println(value);
  return value;
}
