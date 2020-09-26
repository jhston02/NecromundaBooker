using System;
using System.Collections.Generic;
using System.Text;
using UnderHiveBookKeeper.Gangs.Domain.SeedWork;

namespace UnderHiveBookKeeper.Gangs.Domain.Aggregates.GangAggregate
{
    public class Stash : Entity
    {
        public Stash 
        public uint Credits { get; private set; }

        private readonly List<Weapon> _weapons;
        public IReadOnlyCollection<Weapon> Weapons => _weapons;

        private readonly List<Wargear> _wargear;
        public IReadOnlyCollection<Wargear> Weargear => _wargear;
    }
}
