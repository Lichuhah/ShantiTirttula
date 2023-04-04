﻿using ShantiTirttula.Domain.Models;

namespace ShantiTirttula.Domain.Dto.Output
{
    public class TriggerOutput : ApiDto<ITrigger>
    {
        public int Type { get; set; }
        public int SensorNumber { get; set; }
        public float TriggerValue { get; set; }
        public float DeviceValue { get; set; }
        public int Pin { get; set; }
        public bool IsPwm { get; set; }
    }
}