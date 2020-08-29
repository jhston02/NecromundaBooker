using System;
using System.Collections.Generic;
using UnderHiveBookKeeper.Gangs.Domain.Aggregates;
using Xunit;

namespace UnderHiveBookerKeeper.Gangs.Domain.Tests
{
    public class GangTests
    {
        [Fact]
        public void GangCreated_ValidValues_ExpectedValuesFilledIn()
        {
            var gang = new Gang(GangType.Cawdor, 6);
            Assert.True(gang.GangType == GangType.Cawdor && gang.Reputation == 6);
        }

        /*[Theory]
        [InlineData(new List<GangMember>() {  })]
        public void AddMembersToGange_1Leader1Champ_2Gangers_Succeeds(List<GangMember> members)
        {
            var gang = new Gang(GangType.Cawdor, 6);

        }*/
    }
}
