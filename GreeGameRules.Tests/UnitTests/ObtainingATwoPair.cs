using GreedGameRules.Rules;
using GreedGameRules.Tests.CommonData;
using Xunit;

namespace GreedGameRules.Tests.UnitTests
{
    public class ObtainingATwoPair : TwoPairsTestsPositive
    {
        private static readonly DieRoll[] _bothPairs = new DieRoll[] { DieRoll.Five, DieRoll.Five, DieRoll.One, DieRoll.One, DieRoll.Three };
        private DieRollResult result;

        public ObtainingATwoPair()
        {
            var diceSet = new DiceRoll(_bothPairs);
            var pairRule = new PairRule();

            result = pairRule.CountPoints(diceSet);
        }

        [Fact]
        [Trait("Unit", "Pair")]
        [Trait("Unit", "Two pair")]
        public void OccursWhenRollingTwoOnesAndTwoFives()
        {
            Assert.True(result.DiceCombination == _combination, $"Expected {_combination} combination, but got {result.DiceCombination} instead.");
        }

        [Fact]
        [Trait("Unit", "Pair")]
        [Trait("Unit", "Two pair")]
        public void Awards300PtsForTwoPairs()
        {
            Assert.True(result.Points == _points, $"Expected {_points} combination, but got {result.Points} instead.");
        }
    }
}
