using GreedGameRules.DiceProviders;
using GreedGameRules.DiceRollGenerators;
using GreedGameRules.Tests.CommonData;
using GreedGameRules.Rules;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GreedGameRules.Tests.UnitTests
{
    public class ObtainingAThreeOfAKind : ThreeOfAKindTestsPositive
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void CanBeObtainedRollingThreeOfTheSameDie(DieRoll die)
        {
            var result = GetResult(die);
            Assert.True(result.DiceCombination == _combination);
        }

        [Fact]
        [Trait("Unit", "Three of a kind")]
        public void Awards1000PtsForThreeOnes()
        {
            int points = 1000;
            var die = DieRoll.One;

            var result = GetResult(die);

            Assert.True(result.Points == points, $"Awarded {result.Points}, was {((int)die)}, should be {points}");
        }

        [Fact]
        [Trait("Unit", "Three of a kind")]
        public void Awards500PtsForThreeFives()
        {
            int points = 500;
            var die = DieRoll.Five;

            var result = GetResult(die);

            Assert.True(result.Points == points, $"Awarded {result.Points}, was {((int)die)}, should be {points}");
        }

        [Theory]
        [Trait("Unit", "Three of a kind")]
        [MemberData(nameof(Data))]
        public void AwardsAHundredPointsMultipliedByTheNumberOnTheDie(DieRoll die)
        {
            int points = _pointsBase * (int)die;

            var result = GetResult(die);

            Assert.True(result.Points == points, $"Awarded {result.Points}, was {((int)die)}, should be {points}");
        }

        private DieRollResult GetResult(DieRoll die)
        {
            var diceSet = new DiceRoll(FakeDiceRollFactory.GetSetOfRolls(die, 3));
            var threeOfAKind = new ThreeOfAKindRule();
            return threeOfAKind.CountPoints(diceSet);
        }

        public static readonly IEnumerable<object[]> Data = new List<object[]>()
        {
        new object[] { DieRoll.Two },
        new object[] { DieRoll.Three },
        new object[] { DieRoll.Four },
        new object[] { DieRoll.Six }
        };
    }
}
