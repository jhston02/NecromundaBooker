using System;
using System.Collections.Generic;
using System.Text;
using UnderHiveBookKeeper.Gangs.Domain.SeedWork;

namespace UnderHiveBookKeeper.Gangs.Domain.Aggregates.GangAggregate
{
    public class Weapon : Entity
    {
        public string Name { get; private set; }

        public WeaponType WeaponType { get; private set; }

        private readonly List<WeaponProfile> _weaponProfiles;
        public IReadOnlyCollection<WeaponProfile> WeaponProfiles => _weaponProfiles;

    }

    public enum WeaponType
    {
        Basic,
        CC,
        Pistol,
        Special,
        Heavy
    }
}
