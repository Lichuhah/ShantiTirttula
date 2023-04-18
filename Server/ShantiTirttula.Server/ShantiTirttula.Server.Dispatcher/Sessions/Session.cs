using Newtonsoft.Json;
using ShantiTirttula.Server.Dispatcher.Http;
using ShantiTirttula.Server.Dispatcher.Models;
using ShantiTirttula.Server.Dispatcher.Producer;

namespace ShantiTirttula.Server.Dispatcher.Sessions
{
    public class Session
    {
        public McData Mc { get; set; }
        public string Token { get; set; }
        public List<List<McSensorData>> SensorsData { get; set; }
        public List<McDeviceValues> DeviceValues { get; set;}
        public DateTime LastSendTime { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsBusy { get; set; }
        public CommandProducer Producer { get; set; }
        public Session()
        {
            SensorsData = new List<List<McSensorData>>();
            IsBusy = false;
            DeviceValues = new List<McDeviceValues>();
        }
        public void AddSensorsData(List<McSensorData> data)
        {
            this.SensorsData.Add(data);
            //CheckTriggers(data);
            if (DateTime.UtcNow - LastSendTime > TimeSpan.FromSeconds(60))
            {
                SendSensorData();
                //SendCommandsLog();
                this.LastSendTime = DateTime.UtcNow;
                this.SensorsData.Clear();
                //this.CommandLog.Clear();
            }
        }

        public void SetDeviceValues(List<McDeviceValues> data)
        {
            this.DeviceValues.Clear();
            this.DeviceValues.AddRange(data);
        }

        //private void CheckTriggers(List<McSensorData> data)
        //{
        //    foreach (McSensorData sensor in data)
        //    {
        //        List<DispatcherTrigger> triggers = Triggers.Where(x => x.SensorNumber == sensor.SensorId).ToList();
        //        foreach (DispatcherTrigger trigger in triggers)
        //        {
        //            CreateCommand(sensor, trigger);
        //        }
        //    }
        //}

        //private void CreateCommand(McSensorData sensor, DispatcherTrigger trigger)
        //{
        //    bool isTrigger = false;
        //    switch (trigger.Type)
        //    {
        //        case ETriggerType.More: isTrigger = sensor.Value > trigger.TriggerValue; break;
        //        case ETriggerType.Less: isTrigger = sensor.Value < trigger.TriggerValue; break;
        //    }
        //    if (isTrigger)
        //    {
        //        if (this.DeviceValues.FirstOrDefault(x => x.Pin == trigger.Pin)?.Value != trigger.DeviceValue)
        //        {
        //            Commands.Add(new McCommand
        //            {
        //                TriggerId = trigger.Id,
        //                Pin = trigger.Pin,
        //                IsPwm = trigger.IsPwm,
        //                Value = trigger.DeviceValue
        //            });
        //        }
        //    }
        //}

        //public void LoadTriggers()
        //{
        //    string answer = HttpHelper.GetData("/api/ap/triggers", this.Token);
        //    try
        //    {
        //        List<DispatcherTrigger> triggers = JsonConvert.DeserializeObject<List<DispatcherTrigger>>(answer);
        //        Triggers = triggers;
        //    }
        //    catch (Exception ex) { }
        //}

        public void SendSensorData()
        {
            List<int> ids = SensorsData.First().Select(x => x.SensorId).Distinct().ToList();
            List<McSensorData> data = new List<McSensorData>();

            foreach (int id in ids)
            {
                float value = 0;
                foreach (List<McSensorData> package in SensorsData)
                {
                    value += package.Where(x => x.SensorId == id).Average(x => x.Value);
                }
                data.Add(new McSensorData { SensorId = id, Value = value / SensorsData.Count });
            }
            SendAverageDataToServer(data);
        }

        //public void SaveCommandsLog()
        //{
        //    CommandLog.AddRange(Commands);
        //    Commands.Clear();
        //}

        //public bool SendCommandsLog()
        //{
        //    try
        //    {
        //        foreach (McCommand com in CommandLog)
        //        {
        //            HttpHelper.PostData("/api/commandlog", JsonConvert.SerializeObject(com), this.Token);
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return false;
        //    }
        //}

        private bool SendAverageDataToServer(List<McSensorData> data)
        {        
            try
            {
                foreach(McSensorData sensorData in data){
                    HttpHelper.PostData("/api/ap/sensor-data", JsonConvert.SerializeObject(sensorData), this.Token);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
