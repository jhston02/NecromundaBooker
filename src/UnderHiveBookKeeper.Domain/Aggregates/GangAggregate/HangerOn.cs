using System;
using System.Collections.Generic;
using System.Text;

namespace UnderHiveBookKeeper.Gangs.Domain.Aggregates.GangAggregate
{
    public class HangerOn : Fighter
    {
        public HangerOn(GangSpecific gs, HangerOnType hot, FighterInitializationData data) : base(data)
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
