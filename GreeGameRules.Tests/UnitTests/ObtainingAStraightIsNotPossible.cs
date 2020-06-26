using GreedGameRules;
using GreedGameRules.Rules;
using GreeGameRules.Tests.CommonData;
using System.Collections.Generic;
using Xunit;

namespace GreeGameRules.Tests.UnitTests
{
    public class ObtainingAStraightIsNotPossible : NegativeTests
    {
        [Trait("Unit", "Straight")]
        [Theory]
        [MemberData(nameof(Data))]
        public void IfTheDiceAreNotConsecutive(DieRoll[] dice)
        {
            var straight = new StraightRule();

            var result = straight.CountPoints(new DiceRoll(dice));

            Assert.True(result.DiceCombination == _combination, $"Expected {_combination} combination, but got {result.DiceCombination} instead.");
        }

        [Trait("Unit", "Straight")]
        [Theory]
        [MemberData(nameof(Data))]
        public void AndAwardsNoPoints(DieRoll[] dice)
        {
            var straight = new StraightRule();

            var result = straight.CountPoints(new DiceRoll(dice));

            Assert.True(result.Points == _points, $"Expected {_points} combination, but got {result.Points} instead.");
        }

        public static readonly IEnumerable<object[]> Data = new List<object[]>()
        {
            new object[] { new DieRoll[] { DieRoll.One, DieRoll.Three, DieRoll.Four, DieRoll.Five, DieRoll.Six } },
            new object[] { new DieRoll[] { DieRoll.One, DieRoll.Two, DieRoll.Four, DieRoll.Five, DieRoll.Six } },
            new object[] { new DieRoll[] { DieRoll.One, DieRoll.Two, DieRoll.Three, DieRoll.Five, DieRoll.Six }},
            new object[] { new DieRoll[] { DieRoll.One, DieRoll.Two, DieRoll.Three, DieRoll.Four, DieRoll.Six }},
        };
    }
}
