using System;
using System.Collections.Generic;
using System.Text;
using UnderHiveBookKeeper.Gangs.Domain.SeedWork;

namespace UnderHiveBookKeeper.Gangs.Domain.Aggregates
{
    class WeaponProfile : ValueObject
    {
        public string WeaponProfileName { get; private set; }

        public ushort? ShortRange { get; private set; }

        public ushort? LongRange { get; private set; }

        public short? ShortAccuracy { get; private set; }

        public short? LongAccuracy { get; private set; }

        public short? Strength { get; private set; }

        public short? ArmourPen { get; private set; }

        public short? Damage { get; private set; }

        public ShootingProfile ShootingProfile { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return WeaponProfileName;
        }
    }

    enum ShootingProfile
    {
        Normal,
        Template,
        Melee
    }
}
