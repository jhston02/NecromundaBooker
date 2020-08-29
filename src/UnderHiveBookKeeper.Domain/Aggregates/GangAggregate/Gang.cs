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

        public Gang(GangType gangType, ushort repuation, List<GangMember> members)
        {
            if (!ValidateMembers(members, true, out List<string> notifications))
                throw new ArgumentException(string.Join("\r\n", notifications));

            this.GangType = gangType;
            this.Reputation = repuation;
            _members = members;
            _hangerOns = new List<HangerOn>();
        }

        public void AddGangMember(GangMember member)
        {
            List<GangMember> potentialNewGang = (new List<GangMember>() { member }.Concat(_members)).ToList();

            if (!ValidateMembers(potentialNewGang, false, out List<string> notifications))
                throw new ArgumentException(string.Join("\r\n", notifications));

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

        private bool ValidateMembers(List<GangMember> members, bool initial, out List<string> notifications)
        {
            notifications = new List<string>();

            if (!(members.Where(x => x.GangMemberType == GangMemberType.Leader).Count() == 1))
                notifications.Add("Cannot have more than one leader");

            if (initial)
            {
                if (members.Where(x => x.GangMemberType == GangMemberType.Champion).Count() > 2)
                    notifications.Add("Cannot have more than 2 champions in initial list");
            }

            var specialMemberCount = members.Where(x =>
            {
                if (x.GangMemberType == GangMemberType.Champion ||
                x.GangMemberType == GangMemberType.Leader ||
                x.GangMemberType == GangMemberType.Juve)
                    return true;
                return false;
            }).Count();

            var crewCount = members.Where(x => x.GangMemberType == GangMemberType.Ganger).Count();

            if (specialMemberCount > crewCount)
                throw new ArgumentException("Cannot have more specialists than gangers");


            if (notifications.Count() > 0)
                return false;
            else
                return true;
        }
    }
}
