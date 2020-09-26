using System;
using System.Collections.Generic;
using System.Text;

namespace UnderHiveBookKeeper.Gangs.Domain.Aggregates.GangAggregate
{
    public class ExoticBeast : Wargear
    {
        public ushort Move { get; private set; }

        public ushort Weapon_Skill { get; private set; }

        public ushort Balistic_Skill { get; private set; }

        public ushort Strength { get; private set; }

        public ushort Toughness { get; private set; }

        public ushort Wounds { get; private set; }

        public ushort Initiative { get; private set; }

        public ushort Attacks { get; private set; }

        public ushort Leadership { get; private set; }

        public ushort Coolness { get; private set; }

        public ushort Willpower { get; private set; }

        public ushort Intelligence { get; private set; }

        private readonly List<Weapon> _weapons;
        public IReadOnlyCollection<Weapon> Weapons => _weapons;
    }
}
