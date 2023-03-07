﻿namespace ShantiTirttula.Server.Api.Domain.Interfaces.Models
{
    public interface IDevice : IEntity
    {
        public IController Controller { get; set; }
        public IDeviceType Type { get; set; }
        public IList<IDeviceLog> Logs { get; set; }
        public int Pin { get; set; }
        public bool IsAnalog { get; set; }
    }
}