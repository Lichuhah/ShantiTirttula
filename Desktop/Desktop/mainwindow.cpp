#include <QNetworkReply>
#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <QJsonObject>
#include <QJsonDocument>
#include <QNetworkRequest>
#include <QNetworkAccessManager>

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    mainPort = NULL;
    serial = new QSerialPort();
    InitSerial();
    //this->GetSerial();
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::InitSerial(){
  foreach(QSerialPortInfo port, QSerialPortInfo::availablePorts()){
      this->ui->CmbPorts->addItem(port.portName());
      if(port.description()=="USB-SERIAL CH340"){
          mainPort = &port;
          this->ui->CmbPorts->setCurrentIndex(this->ui->CmbPorts->count()-1);
      }
  }
}

void MainWindow::InitWiFi(){
    QJsonObject textObject;
    textObject["command"] = "getwificonfig";
    this->serial->write(QJsonDocument(textObject).toJson(QJsonDocument::Indented));
    //this->ui->TxtMcConfig->setPlainText(QJsonDocument(textObject).toJson(QJsonDocument::Indented));
    serial->waitForBytesWritten(10000);
    serial->waitForReadyRead(10000);
    if(serial->bytesAvailable()){
        QString received = serial->readAll();
        QJsonDocument jsonResponse = QJsonDocument::fromJson(received.toUtf8());
        QJsonObject jsonObject = jsonResponse.object();
        this->ui->TxtWifiSsid->setText(jsonObject["ssid"].toString());
        this->ui->TxtWifiPassword->setText(jsonObject["password"].toString());
        this->ui->TxtMac->setText(jsonObject["mac"].toString());
        this->ui->TxtMcKey->setText(jsonObject["key"].toString());
        if(jsonObject["isconnect"].toBool()){
            this->ui->LblWifiStatus->setText("Wifi is connect.");
            this->ui->BtnWifiConnect->setEnabled(false);
            this->ui->TxtWifiSsid->setEnabled(false);
            this->ui->TxtWifiPassword->setEnabled(false);
        } else {
            this->ui->LblWifiStatus->setText("Wifi is not connect.");
        }
    }
}

void MainWindow::on_CmbPorts_currentIndexChanged(int index)
{
    if(this->mainPort!=NULL){
        this->serial->setPortName(this->mainPort->portName());
        this->serial->setBaudRate(115200);
        this->serial->setDataBits(QSerialPort::Data8);
        this->serial->setParity(QSerialPort::NoParity);
        this->serial->setFlowControl(QSerialPort::NoFlowControl);
        this->serial->setStopBits(QSerialPort::OneStop);

        if (serial->open(QIODevice::ReadWrite)) {
            //connect(this->serial, SIGNAL(readyRead()), this, SLOT(ReadData()));
            this->ui->LblPortStatus->setText("Success");
            this->ui->CmbPorts->setEnabled(false);
            InitWiFi();
        } else {
            this->ui->LblPortStatus->setText(serial->errorString());
            this->ui->CmbPorts->setEnabled(true);
        }
    }
}


void MainWindow::on_BtnPortChange_clicked()
{
    this->ui->CmbPorts->setEnabled(true);
}


void MainWindow::on_BtnWifiChange_clicked()
{
    this->ui->BtnWifiConnect->setEnabled(true);
    this->ui->TxtWifiSsid->setEnabled(true);
    this->ui->TxtWifiPassword->setEnabled(true);
}


void MainWindow::on_BtnWifiConnect_clicked()
{
    QJsonObject textObject, textObjectData;
    textObject["command"] = "setwificonfig";
    textObjectData["ssid"] = this->ui->TxtWifiSsid->text();
    textObjectData["password"] = this->ui->TxtWifiPassword->text();
    textObject["data"] = QString(QJsonDocument(textObjectData).toJson(QJsonDocument::Indented));
    this->serial->write(QJsonDocument(textObject).toJson(QJsonDocument::Indented));
    serial->waitForBytesWritten(10000);
    serial->waitForReadyRead(15000);
    if(serial->bytesAvailable()){
        QString received = serial->readAll();
        QJsonDocument jsonResponse = QJsonDocument::fromJson(received.toUtf8());
        QJsonObject jsonObject = jsonResponse.object();
        this->ui->TxtWifiSsid->setText(jsonObject["ssid"].toString());
        this->ui->TxtWifiPassword->setText(jsonObject["password"].toString());
        if(jsonObject["isconnect"].toBool()){
            this->ui->LblWifiStatus->setText("Wifi is connect.");
            this->ui->BtnWifiConnect->setEnabled(false);
            this->ui->TxtWifiSsid->setEnabled(false);
            this->ui->TxtWifiPassword->setEnabled(false);
        } else {
            this->ui->LblWifiStatus->setText("Wifi is not connect.");
        }
    }
}


void MainWindow::on_BtnLogin_clicked()
{
   QJsonObject textObject;
   textObject["login"] = this->ui->TxtUserLogin->text();
   textObject["password"] = this->ui->TxtUserPassword->text();

   QUrl url("http://localhost:5193/api/users/1");
   QNetworkRequest request(url);
   request.setHeader(QNetworkRequest::ContentTypeHeader, "application/json");

   QNetworkAccessManager *manager = new QNetworkAccessManager(this);

   QNetworkReply *reply = manager->get(request);//, QJsonDocument(textObject).toJson(QJsonDocument::Indented));
   QObject::connect(reply, &QNetworkReply::finished, [reply, this]() {
      QString ReplyText = reply->readAll();
      //QJsonParseError json_error;
      QJsonDocument json = QJsonDocument::fromJson(ReplyText.toUtf8());
      QJsonObject jsonObject = json.object();
      if(jsonObject["success"].toBool()){
          this->ui->lblUserStatus->setText("success");
          this->ui->BtnGetMcKey->setEnabled(true);
      } else {
          this->ui->lblUserStatus->setText("error");
          this->ui->BtnGetMcKey->setEnabled(false);
      }
      reply->deleteLater();
    });
}



void MainWindow::on_BtnGetMcKey_clicked()
{
    QJsonObject textObject;
    textObject["login"] = this->ui->TxtUserLogin->text();
    textObject["password"] = this->ui->TxtUserPassword->text();
    textObject["mac"] = this->ui->TxtMac->text();

    QUrl url("http://localhost:5193/api/mc/signup");
    QNetworkRequest request(url);
    request.setHeader(QNetworkRequest::ContentTypeHeader, "application/json");

    QNetworkAccessManager *manager = new QNetworkAccessManager(this);
    QNetworkReply *reply = manager->post(request, QJsonDocument(textObject).toJson(QJsonDocument::Indented));
    QObject::connect(reply, &QNetworkReply::finished, [reply, this]() {
       QString ReplyText = reply->readAll();
       //QJsonParseError json_error;
       QJsonDocument json = QJsonDocument::fromJson(ReplyText.toUtf8());
       QJsonObject jsonObject = json.object();
       QJsonObject jsonKey = jsonObject["data"].toObject();
       if(jsonObject["success"].toBool()){
           this->ui->TxtMcKey->setText(jsonObject["data"].toString());
           QJsonObject textObject, textObjectData;
           textObject["command"] = "setkeyconfig";
           textObjectData["key"] = jsonObject["data"].toString();
           textObject["data"] = QString(QJsonDocument(textObjectData).toJson(QJsonDocument::Indented));
           this->serial->write(QJsonDocument(textObject).toJson(QJsonDocument::Indented));
           serial->waitForBytesWritten(10000);
           serial->waitForReadyRead(15000);
       } else {
           this->ui->lblUserStatus->setText("error");

       }
       reply->deleteLater();
     });
}

