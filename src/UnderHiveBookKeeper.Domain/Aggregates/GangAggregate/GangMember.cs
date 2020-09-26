using System;
using System.Collections.Generic;
using System.Text;
using UnderHiveBookKeeper.Gangs.Domain.SeedWork;

namespace UnderHiveBookKeeper.Gangs.Domain.Aggregates.GangAggregate
{
    public class GangMember : Fighter
    {
        public GangMemberType GangMemberType { get; private set; }

        public GangMember(GangMemberType gmt, FighterInitializationData data) : base(data)
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
