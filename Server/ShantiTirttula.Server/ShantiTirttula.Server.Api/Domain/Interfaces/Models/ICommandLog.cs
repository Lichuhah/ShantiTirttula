﻿namespace ShantiTirttula.Server.Api.Domain.Interfaces.Models
{
    public interface ICommandLog : IEntity
    {
        public IMcAuth Auth { get; set; }
        public ITrigger Trigger { get; set; }
        public DateTime DateTime { get; set; }
    }
}