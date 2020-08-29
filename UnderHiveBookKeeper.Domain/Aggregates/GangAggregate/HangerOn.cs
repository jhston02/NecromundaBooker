using System;
using System.Collections.Generic;
using System.Text;

namespace UnderHiveBookKeeper.Gangs.Domain.Aggregates.GangAggregate
{
    class HangerOn : Fighter
    {
        public GangSpecific GangSpecific { get; private set; }
    }

    enum GangSpecific
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
