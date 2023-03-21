#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QtSerialPort/QSerialPort>
#include <QtSerialPort/QSerialPortInfo>
#include <QNetworkReply>

QT_BEGIN_NAMESPACE
namespace Ui { class MainWindow; }
QT_END_NAMESPACE

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    MainWindow(QWidget *parent = nullptr);
    ~MainWindow();
    void InitSerial();
    void InitWiFi();

private slots:
    //void ReadData();

    void on_CmbPorts_currentIndexChanged(int index);

    void on_BtnPortChange_clicked();

    void on_BtnWifiChange_clicked();

    void on_BtnWifiConnect_clicked();

    void on_BtnLogin_clicked();

    void on_BtnGetMcKey_clicked();

private:
    Ui::MainWindow *ui;
    QSerialPortInfo *mainPort;
    QSerialPort *serial;
};
#endif // MAINWINDOW_H
