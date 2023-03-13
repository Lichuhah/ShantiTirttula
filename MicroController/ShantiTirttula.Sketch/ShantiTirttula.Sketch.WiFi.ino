bool WIFIinit() {
  // Попытка подключения к точке доступа
  WiFi.mode(WIFI_STA);
  byte tries = 11;
  WiFi.begin(wifi_ssid.c_str(), wifi_password.c_str());
  // Делаем проверку подключения до тех пор пока счетчик tries
  // не станет равен нулю или не получим подключение
  while (--tries && WiFi.status() != WL_CONNECTED)
  {
    //Serial.print(".");
    delay(1000);
  }
  if (WiFi.status() != WL_CONNECTED)
  {
    // Если не удалось подключиться запускаем в режиме AP
    //Serial.println("");
    //Serial.println("WiFi up AP");
    return false;
  }
  else {
    // Иначе удалось подключиться отправляем сообщение
    // о подключении и выводим адрес IP
    //Serial.println("");
    //Serial.println("WiFi connected");
    //Serial.println("IP address: ");
    //Serial.println(WiFi.localIP());
    return true;
  }
}
