﻿using System;
using System.Collections.Generic;
using System.Text;
using UnderHiveBookKeeper.Gangs.Domain.SeedWork;

namespace UnderHiveBookKeeper.Gangs.Domain.Aggregates.GangAggregate
{
    public class Skill : Entity
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public string Category { get; set; }
    }
}
