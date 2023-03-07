﻿using NHibernate.Mapping.ByCode;
using ShantiTirttula.Server.Api.Domain.Implementations.Models;

namespace ShantiTirttula.Server.Api.Domain.Implementations.Mappings
{
    public class SensorTypeMapping : EntityMapping<SensorType>
    {
        public SensorTypeMapping() : base("MC_SENSOR_TYPE")
        {
            Property(x => x.Name, map =>
            {
                map.Column("NUMBER");
            });
            Bag(x => x.Sensors, map =>
            {
                map.Lazy(CollectionLazy.Lazy);
                map.BatchSize(30);
                map.Cascade(Cascade.All);
                map.Inverse(true);
                map.Key(key => { key.Column("TYPE_ID"); });
            }, action => { action.OneToMany(x => { x.Class(typeof(Sensor)); }); });
        }
    }
}
