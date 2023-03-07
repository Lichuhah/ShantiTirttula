﻿using ShantiTirttula.Server.Api.Domain.Interfaces.Managers;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Managers
{
    public class ControllerTypeManager : EntityManager<IControllerType>, IControllerTypeManager
    {
        public ControllerTypeManager(NHibernate.ISession session) : base(session)
        {

        }
    }
}
