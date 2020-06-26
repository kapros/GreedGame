using GreedGameRules.Rules;
using GreedGameRules.Tests.CommonData;
using Xunit;

namespace GreedGameRules.Tests.UnitTests
{
    public class ObtainingAPair : PairTestsPositive
    {
        [Fact]
        [Trait("Unit", "Pair")]
        public void OccursWhenTwoOnesAreRolled()
        {
            var diceSet = new DiceRoll(_pairOfOnes);
            var pairRule = new PairRule();

            var result = pairRule.CountPoints(diceSet);

            Assert.True(result.DiceCombination == _combination, $"Expected {_combination} combination, but got {result.DiceCombination} instead.");
        }

        [Fact]
        [Trait("Unit", "Pair")]
        public void Awards200PtsForPairOfOnes()
        {
            var diceSet = new DiceRoll(_pairOfOnes);
            var pairRule = new PairRule();

            var result = pairRule.CountPoints(diceSet);

            Assert.True(result.Points == _onesPoints, $"Expected {_onesPoints} combination, but got {result.Points} instead.");
        }

        [Fact]
        [Trait("Unit", "Pair")]
        public void OccursWhenTwoFivesAreRolled()
        {
            var diceSet = new DiceRoll(_pairOfFives);
            var pairRule = new PairRule();

            var result = pairRule.CountPoints(diceSet);

            Assert.True(result.DiceCombination == _combination, $"Expected {_combination} combination, but got {result.DiceCombination} instead.");
        }

        [Fact]
        [Trait("Unit", "Pair")]
        public void Awards100PtsForPairOfFives()
        {
            var diceSet = new DiceRoll(_pairOfFives);
            var pairRule = new PairRule();

            var result = pairRule.CountPoints(diceSet);

            Assert.True(result.Points == _fivesPoints, $"Expected {_fivesPoints} combination, but got {result.Points} instead.");
        }
    }
}
