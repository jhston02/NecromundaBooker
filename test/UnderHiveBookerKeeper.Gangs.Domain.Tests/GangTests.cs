using System;
using System.Collections.Generic;
using UnderHiveBookKeeper.Gangs.Domain.Aggregates;
using Xunit;

namespace UnderHiveBookerKeeper.Gangs.Domain.Tests
{
    public class GangTests
    {
        public class TestDataGenerator
        {
            public static IEnumerable<object[]> GetValidData()
            {

                yield return new object[] { new GangMember(GangMemberType.Leader, GetFighterData("test", 1,1,1,1,1,1,1,1,1,1,1,1, false, null)),
                new GangMember(GangMemberType.Ganger, GetFighterData("test1", 1,1,1,1,1,1,1,1,1,1,1,1, false, null )),
                new GangMember(GangMemberType.Ganger, GetFighterData("test2", 1,1,1,1,1,1,1,1,1,1,1,1, false, null )),
                new GangMember(GangMemberType.Champion, GetFighterData("test3", 1,1,1,1,1,1,1,1,1,1,1,1, false, null )) };

                yield return new object[] { new GangMember(GangMemberType.Leader, GetFighterData("test", 1,1,1,1,1,1,1,1,1,1,1,1, false, null)),
                new GangMember(GangMemberType.Ganger, GetFighterData("test1", 1,1,1,1,1,1,1,1,1,1,1,1, false, null )),
                new GangMember(GangMemberType.Ganger, GetFighterData("test2", 1,1,1,1,1,1,1,1,1,1,1,1, false, null )),
                new GangMember(GangMemberType.Juve, GetFighterData("test3", 1,1,1,1,1,1,1,1,1,1,1,1, false, null )) };
            }

            public static IEnumerable<object[]> GetInvalidDataNotEnoughGangers()
            {
                yield return new object[] { new GangMember(GangMemberType.Leader, GetFighterData("test", 1,1,1,1,1,1,1,1,1,1,1,1, false, null)),
                new GangMember(GangMemberType.Ganger, GetFighterData("test1", 1,1,1,1,1,1,1,1,1,1,1,1, false, null )),
                new GangMember(GangMemberType.Ganger, GetFighterData("test2", 1,1,1,1,1,1,1,1,1,1,1,1, false, null )),
                new GangMember(GangMemberType.Champion, GetFighterData("test3", 1,1,1,1,1,1,1,1,1,1,1,1, false, null )),
                new GangMember(GangMemberType.Juve, GetFighterData("test3", 1,1,1,1,1,1,1,1,1,1,1,1, false, null ))};

                yield return new object[] { new GangMember(GangMemberType.Leader, GetFighterData("test", 1,1,1,1,1,1,1,1,1,1,1,1, false, null)),
                new GangMember(GangMemberType.Ganger, GetFighterData("test1", 1,1,1,1,1,1,1,1,1,1,1,1, false, null )),
                new GangMember(GangMemberType.Ganger, GetFighterData("test2", 1,1,1,1,1,1,1,1,1,1,1,1, false, null )),
                new GangMember(GangMemberType.Champion, GetFighterData("test3", 1,1,1,1,1,1,1,1,1,1,1,1, false, null )),
                new GangMember(GangMemberType.Champion, GetFighterData("test4", 1,1,1,1,1,1,1,1,1,1,1,1, false, null ))};
            }

            public static IEnumerable<object[]> GetInvalidInitial()
            {
                yield return new object[] { new GangMember(GangMemberType.Leader, GetFighterData("test", 1,1,1,1,1,1,1,1,1,1,1,1, false, null)),
                new GangMember(GangMemberType.Ganger, GetFighterData("test1", 1,1,1,1,1,1,1,1,1,1,1,1, false, null )),
                new GangMember(GangMemberType.Ganger, GetFighterData("test2", 1,1,1,1,1,1,1,1,1,1,1,1, false, null )),
                new GangMember(GangMemberType.Ganger, GetFighterData("test3", 1,1,1,1,1,1,1,1,1,1,1,1, false, null )),
                new GangMember(GangMemberType.Ganger, GetFighterData("test7", 1,1,1,1,1,1,1,1,1,1,1,1, false, null )),
                new GangMember(GangMemberType.Champion, GetFighterData("test4", 1,1,1,1,1,1,1,1,1,1,1,1, false, null )),
                new GangMember(GangMemberType.Champion, GetFighterData("test5", 1,1,1,1,1,1,1,1,1,1,1,1, false, null )),
                new GangMember(GangMemberType.Champion, GetFighterData("test6", 1,1,1,1,1,1,1,1,1,1,1,1, false, null ))};
            }

            private static FighterInitializationData GetFighterData(string name, ushort move, ushort weaponSkill, ushort balisticSkill,
            ushort strength, ushort toughness, ushort wounds, ushort initiative,
            ushort attacks, ushort leadership, ushort willPower, ushort intelligence, ushort coolness,
            bool isSpecialist, List<Trait> traits)
            {
                return new FighterInitializationData()
                {
                    Name = name,
                    Move = move,
                    Weapon_Skill = weaponSkill,
                    Balistic_Skill = balisticSkill,
                    Strength = strength,
                    Toughness = toughness,
                    Initiative = initiative,
                    IsSpecialist = isSpecialist,
                    Attacks = attacks,
                    Wounds = wounds,
                    Leadership = leadership,
                    Willpower = willPower,
                    Intelligence = intelligence,
                    Traits = traits,
                    Coolness = coolness,
                };
            }
        }

        [Theory]
        [MemberData(nameof(TestDataGenerator.GetValidData), MemberType = typeof(TestDataGenerator))]
        public void CreateGang_1Leader1Champ_2Gangers_Succeeds(GangMember a, GangMember b, GangMember c, GangMember d)
        {
            var gang = new Gang(GangType.Cawdor, 6, new List<GangMember>()
            {
                a,
                b,
                c,
                d
            });
        }

        [Theory]
        [MemberData(nameof(TestDataGenerator.GetInvalidDataNotEnoughGangers), MemberType = typeof(TestDataGenerator))]
        public void CreateGang_1Leader2Champ_2Gangers_ThrowsArgumentException(GangMember a, GangMember b, GangMember c, GangMember d, GangMember e)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var gang = new Gang(GangType.Cawdor, 6, new List<GangMember>()
                {
                    a,
                    b,
                    c,
                    d,
                    e
                });
            });
        }

        [Theory]
        [MemberData(nameof(TestDataGenerator.GetValidData), MemberType = typeof(TestDataGenerator))]
        public void AddGangMember_1Leader1Champ_2Gangers_Succeeds(GangMember a, GangMember b, GangMember c, GangMember d)
        {
            var gang = new Gang(GangType.Cawdor, 6, new List<GangMember>()
            {
                a,
                b,
                c
            });

            gang.AddGangMember(d);
        }

        [Theory]
        [MemberData(nameof(TestDataGenerator.GetInvalidDataNotEnoughGangers), MemberType = typeof(TestDataGenerator))]
        public void AddGangMember_1Leader2Champ_2Gangers_ThrowsArgumentException(GangMember a, GangMember b, GangMember c, GangMember d, GangMember e)
        {
            var gang = new Gang(GangType.Cawdor, 6, new List<GangMember>()
                {
                    a,
                    b,
                    c,
                    d
                });
            Assert.Throws<ArgumentException>(() =>
            {
                gang.AddGangMember(e);
            });
        }

        /*[Theory]
        [MemberData(nameof(TestDataGenerator.GetInvalidDataNotEnoughGangers), MemberType = typeof(TestDataGenerator))]
        public void AddGangMember_1Leader3Champ_4Gangers_ThrowsArgumentException(GangMember a, GangMember b, GangMember c, GangMember d, GangMember e, GangMember f, GangMember g, GangMember h)
        {
            var gang = new Gang(GangType.Cawdor, 6, new List<GangMember>()
                {
                    a,
                    b,
                    c,
                    d
                });
            Assert.Throws<ArgumentException>(() =>
            {
                gang.AddGangMember(e);
            });
        }*/
    }
}
