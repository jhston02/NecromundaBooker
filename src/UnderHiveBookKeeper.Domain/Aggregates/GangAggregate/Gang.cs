using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnderHiveBookKeeper.Gangs.Domain.Aggregates.GangAggregate;
using UnderHiveBookKeeper.Gangs.Domain.SeedWork;

namespace UnderHiveBookKeeper.Gangs.Domain.Aggregates
{
    public class Gang : Entity, IAggregateRoot
    {
        public GangType GangType { get; private set; }

        public uint GangRating { get; private set; }

        public ushort Reputation { get; private set; }

        public uint Wealth { get; private set; }

        private readonly List<GangMember> _members;
        public IReadOnlyCollection<GangMember> Members => _members;

        private readonly List<HangerOn> _hangerOns;
        public IReadOnlyCollection<HangerOn> HangerOns => _hangerOns;

        public Gang(GangType gangType, uint gangRating)
        {
            this.GangType = gangType;
            this.GangRating = gangRating;
            _members = new List<GangMember>();
            _hangerOns = new List<HangerOn>();
        }

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

            if (member.GangMemberType == GangMemberType.Champion && (Members.Where(x => x.GangMemberType == GangMemberType.Champion).Count() > 1))
            {
                throw new ArgumentException("Cannot not have more than two champions");
            }

            _members.Add(member);
        }

        public void RemoveGangMember(GangMember member)
        {
            _members.Remove(member);
        }

        public void RemoveHangerOn(HangerOn ho)
        {
            _hangerOns.Remove(ho);
        }

        public void AddHangerOn(HangerOn ho)
        {
            if ((Reputation % 5) + 1 < _hangerOns.Count())
                _hangerOns.Add(ho);
            else
                throw new ArgumentException("Cannot add Hanger On at maximimum allowed with Rep");

            if (ho.GangSpecific != GangSpecific.None && ho.GangSpecific.ToString() != GangType.ToString())
                throw new ArgumentException("Cannot give gang specific hanger on to different gang");
        }

        public void AddReputation(ushort reputation)
        {
            Reputation += reputation;
        }

        public void RemoveReputation(ushort reputation)
        {
            if (reputation > Reputation)
                Reputation = 0;
            else
                Reputation = (ushort)(Reputation - reputation);
        }
    }
}
