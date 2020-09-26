using System;
using System.Collections.Generic;
using System.Text;
using UnderHiveBookKeeper.Gangs.Domain.SeedWork;

namespace UnderHiveBookKeeper.Gangs.Domain.Aggregates
{
    public abstract class Fighter : Entity
    {
        public Fighter(FighterInitializationData data)
        {
            this.Name = data.Name;
            this.Move = data.Move;
            this.Weapon_Skill = data.Weapon_Skill;
            this.Balistic_Skill = data.Balistic_Skill;
            this.Strength = data.Strength;
            this.Toughness = data.Toughness;
            this.Initiative = data.Initiative;
            this.IsSpecialist = data.IsSpecialist;
            this.Attacks = data.Attacks;
            this.Wounds = data.Wounds;
            this.Leadership = data.Leadership;
            this.Willpower = data.Willpower;
            this.Intelligence = data.Intelligence;
            this._trait = data.Traits;
            this.Coolness = data.Coolness;
        }

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

    public class FighterInitializationData
    {
        public string Name { get; set; }

        public ushort Move { get; set; }

        public ushort Weapon_Skill { get; set; }

        public ushort Balistic_Skill { get; set; }

        public ushort Strength { get; set; }

        public ushort Toughness { get; set; }

        public ushort Wounds { get; set; }

        public ushort Initiative { get; set; }

        public ushort Attacks { get; set; }

        public ushort Leadership { get; set; }

        public ushort Coolness { get; set; }

        public ushort Willpower { get; set; }

        public ushort Intelligence { get; set; }

        public bool IsSpecialist { get; set; }

        public List<Trait> Traits { get; set; }
    }
}
