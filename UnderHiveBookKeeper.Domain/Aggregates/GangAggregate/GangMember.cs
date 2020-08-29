using System;
using System.Collections.Generic;
using System.Text;
using UnderHiveBookKeeper.Gangs.Domain.SeedWork;

namespace UnderHiveBookKeeper.Gangs.Domain.Aggregates
{
    class GangMember : Entity
    {
        public GangMemberType GangMemberType { get; private set; }

        public string Name { get; private set; }

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

        public bool IsSpecialist { get; private set; }

        private readonly List<Weapon> _weapons;
        public IReadOnlyCollection<Weapon> Weapons => _weapons;

        private readonly List<Wargear> _wargear;
        public IReadOnlyCollection<Wargear> Weargear => _wargear;

        private readonly List<Skill> _skill;
        public IReadOnlyCollection<Skill> Skill => _skill;

        private readonly List<Trait> _trait;
        public IReadOnlyCollection<Trait> Trait => _trait;
    }

    enum GangMemberType
    {
        Leader,
        Champion,
        Ganger,
        Juve,
        Brute,
        BountyHunter,
        Hired_Gun
    }
}
