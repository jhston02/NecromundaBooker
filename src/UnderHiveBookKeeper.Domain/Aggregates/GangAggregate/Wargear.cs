using System;
using System.Collections.Generic;
using System.Text;
using UnderHiveBookKeeper.Gangs.Domain.SeedWork;

namespace UnderHiveBookKeeper.Gangs.Domain.Aggregates.GangAggregate
{
    public class Wargear : Entity
    {
        public string Name { get; set; }
        
        public string Description { get; set; }
    }
}
