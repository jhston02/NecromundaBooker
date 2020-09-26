using System;
using System.Collections.Generic;
using System.Text;
using UnderHiveBookKeeper.Gangs.Domain.SeedWork;

namespace UnderHiveBookKeeper.Gangs.Domain.Aggregates.GangAggregate
{
    public abstract class Expense : Entity
    {
        public Expense(uint cost)
        {
            Cost = cost;
        }

        public uint Cost { get; private set; }
    }
}
