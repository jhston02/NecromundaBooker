using System;
using System.Collections.Generic;
using System.Text;
using UnderHiveBookKeeper.Gangs.Domain.SeedWork;

namespace UnderHiveBookKeeper.Gangs.Domain.Aggregates
{
    public class GangMember : Fighter
    {
        public GangMemberType GangMemberType { get; private set; }

        public GangMember(GangMemberType gmt, string name, ushort move, ushort weaponSkill, ushort balisticSkill,
            ushort strength, ushort toughness, ushort wounds, ushort initiative,
            ushort attacks, ushort leadership, ushort willPower, ushort intelligence, ushort coolness,
            bool isSpecialist, List<Trait> traits) : base(name, move, weaponSkill,balisticSkill, strength, toughness, wounds, initiative, 
                attacks, leadership, willPower, intelligence, coolness, isSpecialist, traits)
        {
            this.GangMemberType = gmt;
        }
    }

    public enum GangMemberType
    {
        Leader,
        Champion,
        Ganger,
        Juve
    }
}
