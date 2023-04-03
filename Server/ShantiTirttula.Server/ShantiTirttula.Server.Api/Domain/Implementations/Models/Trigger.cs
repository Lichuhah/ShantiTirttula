﻿using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Models
{
    public class Trigger : Entity, ITrigger
    {
        public virtual ITriggerType Type { get; set; }
        public virtual ISensor Sensor { get; set; }
        public virtual IDevice Device { get; set; }
        public virtual float TriggerValue { get; set; }
        public virtual float DeviceValue { get; set; }
        public virtual IList<ICommandLog> Logs { get; set; }
        public virtual IAuth Auth { get; set; }
    }
}
