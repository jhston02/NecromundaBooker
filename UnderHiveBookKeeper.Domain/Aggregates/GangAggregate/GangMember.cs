using System;
using System.Collections.Generic;
using System.Text;
using UnderHiveBookKeeper.Gangs.Domain.SeedWork;

namespace UnderHiveBookKeeper.Gangs.Domain.Aggregates
{
    class GangMember : Fighter
    {
        public GangMemberType GangMemberType { get; private set; }
    }

    enum GangMemberType
    {
        Leader,
        Champion,
        Ganger,
        Juve
    }
}
