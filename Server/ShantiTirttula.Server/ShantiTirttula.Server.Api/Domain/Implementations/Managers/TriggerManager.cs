﻿using ShantiTirttula.Server.Api.Domain.Interfaces.Managers;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Managers
{
    public class TriggerManager : EntityManager<ITrigger>, ITriggerManager
    {
        public TriggerManager(NHibernate.ISession session) : base(session)
        {

        }
    }
}