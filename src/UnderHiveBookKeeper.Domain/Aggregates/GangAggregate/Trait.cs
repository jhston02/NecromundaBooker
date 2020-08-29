using System;
using System.Collections.Generic;
using System.Text;
using UnderHiveBookKeeper.Gangs.Domain.SeedWork;

namespace UnderHiveBookKeeper.Gangs.Domain.Aggregates
{
    public class Trait : ValueObject
    {
        public string Name { get; set; }

        public string Description { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Name;
        }
    }
}
