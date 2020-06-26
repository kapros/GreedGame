using GreedGameRules;
using GreedGameRules.DiceProviders;
using GreedGameRules.Rules;
using GreeGameRules.Tests.CommonData;
using System.Collections.Generic;
using Xunit;

namespace GreeGameRules.Tests.UnitTests
{
    public class ObtainingAFiveOfAKind : FiveOfAKindTests
    {
        [Trait("Unit", "Five of a kind")]
        [Theory]
        [MemberData(nameof(Data))]
        public void CanBeAchievedByFiveOfAnyRoll(DieRoll dice)
        {
            var diceSet = new DiceRoll(FakeDiceRollFactory.GetSetOfRolls(dice, 5));
            var fiveOfAKind = new FiveOfAKindRule();

            var result = fiveOfAKind.CountPoints(diceSet);

            Assert.True(result.Points == _points);
        }

        [Trait("Unit", "Five of a kind")]
        [Theory]
        [MemberData(nameof(Data))]
        public void Awards1500PtsForAllRolls(DieRoll dice)
        {
            var diceSet = new DiceRoll(FakeDiceRollFactory.GetSetOfRolls(dice, 5));
            var fiveOfAKind = new FiveOfAKindRule();

            var result = fiveOfAKind.CountPoints(diceSet);

            Assert.True(result.Points == _points);
        }

        public static readonly IEnumerable<object[]> Data = new List<object[]>()
        {
        new object[] { DieRoll.One },
        new object[] { DieRoll.Two },
        new object[] { DieRoll.Three },
        new object[] { DieRoll.Four },
        new object[] { DieRoll.Five },
        new object[] { DieRoll.Six }
        };
    }
}
