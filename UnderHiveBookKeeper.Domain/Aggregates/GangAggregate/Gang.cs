using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnderHiveBookKeeper.Gangs.Domain.SeedWork;

namespace UnderHiveBookKeeper.Gangs.Domain.Aggregates
{
    class Gang : Entity, IAggregateRoot
    {
        public GangType GangType { get; private set; }

        private readonly List<GangMember> _members;
        public IReadOnlyCollection<GangMember> Members => _members;

        public void AddGangMember(GangMember member)
        {
            var isSpecialist = member.GangMemberType == GangMemberType.Champion ||
                    member.GangMemberType == GangMemberType.Leader ||
                    member.GangMemberType == GangMemberType.Juve;

            if (isSpecialist)
            {
                var specialMemberCount = Members.Where(x =>
                {
                    if (x.GangMemberType == GangMemberType.Champion &&
                    x.GangMemberType == GangMemberType.Leader &&
                    x.GangMemberType == GangMemberType.Juve)
                        return true;
                    return false;
                }).Count();

                var crewCount = Members.Where(x => x.GangMemberType == GangMemberType.Ganger).Count();

                if (specialMemberCount > crewCount)
                    throw new ArgumentException("Cannot add more specialists. Must add another ganger");
            }

            if (member.GangMemberType == GangMemberType.Leader && (Members.Where(x => x.GangMemberType == GangMemberType.Leader).Count() > 0))
            {
                throw new ArgumentException("Cannot not have more than one leader");
            }


        }
    }
}
