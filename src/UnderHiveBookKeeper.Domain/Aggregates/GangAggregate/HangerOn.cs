using System;
using System.Collections.Generic;
using System.Text;

namespace UnderHiveBookKeeper.Gangs.Domain.Aggregates.GangAggregate
{
    public class HangerOn : Fighter
    {
        public HangerOn(GangSpecific gs, HangerOnType hot, string name, ushort move, ushort weaponSkill, ushort balisticSkill,
            ushort strength, ushort toughness, ushort wounds, ushort initiative,
            ushort attacks, ushort leadership, ushort willPower, ushort intelligence, ushort coolness,
            bool isSpecialist, List<Trait> traits) : base(name, move, weaponSkill, balisticSkill, strength, toughness, wounds, initiative,
                attacks, leadership, willPower, intelligence, coolness, isSpecialist, traits)
        {
            this.GangSpecific = gs;
            this.HangerOnType = hot;
        }

        public GangSpecific GangSpecific { get; private set; }

        public HangerOnType HangerOnType { get; private set; }
    }

    public enum GangSpecific
    {
        Palanite_Enforcers,
        Corpse_Grinder_Cults,
        Van_Saar,
        Delaque,
        Orlock,
        Escher,
        Cawdor,
        Goliath,
        None
    }

    public enum HangerOnType
    {
        HangerOn,
        Brute
    }
}
