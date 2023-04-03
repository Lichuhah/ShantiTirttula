using ShantiTirttula.Domain.Enums;
using ShantiTirttula.Domain.Models;

namespace ShantiTirttula.Repository.Helpers
{
    public static class SensorAlgorithmHelper
    {
        public static double GetValue(ISensorData data)
        {
            switch (data.Sensor.Type.Algorithm)
            {
                case ESensorDataAlgorithm.ClassicAlgorithm: return ClassicAlgorithm(data);
                default: return data.Value;
            }
        }

        private static double ClassicAlgorithm(ISensorData data)
        {
            double voltage = data.Value * (data.Sensor.Controller.Voltage / data.Sensor.Controller.AdcMax);
            double value = voltage * ((data.Sensor.Type.MaxValue - data.Sensor.Type.MinValue) / data.Sensor.Type.Power);
            if (data.Sensor.Type.IsReverse)
                return data.Sensor.Type.MaxValue - value;
            else
                return data.Sensor.Type.MinValue + value;
        }
    }
}
