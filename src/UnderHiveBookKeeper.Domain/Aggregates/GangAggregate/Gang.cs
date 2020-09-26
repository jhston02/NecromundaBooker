using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnderHiveBookKeeper.Gangs.Domain.SeedWork;

namespace UnderHiveBookKeeper.Gangs.Domain.Aggregates.GangAggregate
{
    public class Gang : Entity, IAggregateRoot
    {
        public GangType GangType { get; private set; }

        public uint GangRating { get; private set; }

        public ushort Reputation { get; private set; }

        public uint Wealth 
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Stash Stash { get; private set; }

        private readonly List<GangMember> _members;
        public IReadOnlyCollection<GangMember> Members => _members;

        private readonly List<HangerOn> _hangerOns;
        public IReadOnlyCollection<HangerOn> HangerOns => _hangerOns;

        public Gang(GangType gangType, ushort reputation, List<GangMember> members, uint credits)
        {
            if (!ValidateMembers(members, true, out List<string> notifications))
                throw new ArgumentException(string.Join("\r\n", notifications));

            this.GangType = gangType;
            this.Reputation = reputation;
            _members = members;
            _hangerOns = new List<HangerOn>();
            this.Stash = new Stash(credits);
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
            if (!ValidateMembers(_members, false, out List<string> notifications))
            {
                _members.Add(member);
                throw new ArgumentException("Cannot remove gange member. Removing would result in invalid Gang");
            }
        }

        public void RemoveHangerOn(HangerOn ho)
        {
            _hangerOns.Remove(ho);
        }

        public void AddHangerOn(HangerOn ho)
        {
            if (GetValidHangerOnCount(Reputation) > _hangerOns.Count())
                _hangerOns.Add(ho);
            else
                throw new ArgumentException("Cannot add Hanger On at maximimum allowed with reputation");

            if (ho.GangSpecific != GangSpecific.None && ho.GangSpecific.ToString().ToLower() != GangType.ToString().ToLower())
                throw new ArgumentException("Cannot give gang specific hanger on to different gang");
        }

        public void AddReputation(ushort reputation)
        {
            Reputation += reputation;
        }

        public void RemoveReputation(ushort reputation)
        {
            var oldReputation = Reputation;
            if (reputation > Reputation)
                Reputation = 0;
            else
                Reputation = (ushort)(Reputation - reputation);

            if (HangerOns.Count() > GetValidHangerOnCount(Reputation))
            {
                Reputation = oldReputation;
                throw new ArgumentException("Too many Hanger Ons/Brutes for reputation");
            }
        }

        private ushort GetValidHangerOnCount(ushort reputation)
        {
            return (ushort)((Reputation / 5) + 1);
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
