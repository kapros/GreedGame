using GreedGameRules;
using GreedGameRules.Rules;
using GreeGameRules.Tests.CommonData;
using Xunit;

namespace GreeGameRules.Tests.UnitTests
{
    public class ObtainingALowStraight : LowStraightTestsPositive
    {
        private DieRollResult result;

        public ObtainingALowStraight()
        {
            var dice = new DieRoll[] { DieRoll.One, DieRoll.Two, DieRoll.Four, DieRoll.Three, DieRoll.Five };
            var diceSet = new DiceRoll(dice);
            var rule = new StraightRule();
            result = rule.CountPoints(diceSet);
        }

        [Fact]
        [Trait("Unit", "Straight")]
        [Trait("Unit", "Low straight")]
        public void Awards2000Pts()
        {
            Assert.True(result.Points == _points, $"Awarded {result.Points} instead of {_points}.");
        }

        [Fact]
        [Trait("Unit", "Straight")]
        [Trait("Unit", "Low straight")]
        public void OccursWhenRollingOneThroughFive()
        {
            Assert.True((result.DiceCombination == _combination), $"Expected {_combination} combination, but got {result.DiceCombination} instead.");
        }
    }
}
