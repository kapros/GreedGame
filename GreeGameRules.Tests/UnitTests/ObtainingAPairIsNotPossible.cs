using GreedGameRules.Rules;
using GreeGameRules.Tests.CommonData;
using Xunit;

namespace GreedGameRules.Tests.UnitTests
{
    public class ObtainingAPairIsNotPossible : NegativeTests
    {
        [Theory]
        [Trait("Unit", "Pair")]
        [InlineData(new DieRoll[] { DieRoll.Two, DieRoll.Four, DieRoll.Four, DieRoll.Two, DieRoll.Three })]
        [InlineData(new DieRoll[] { DieRoll.Five, DieRoll.Three, DieRoll.Three, DieRoll.Six, DieRoll.Six })]
        public void IfNonOnesOrFivesAreRolled(DieRoll[] dice)
        {
            var diceSet = new DiceRoll(dice);
            var pairRule = new PairRule();

            var result = pairRule.CountPoints(diceSet);

            Assert.True(result.DiceCombination == _combination, $"Expected {_combination} combination, but got {result.DiceCombination} instead.");
            Assert.True(result.Points == _points, $"Expected {_points} combination, but got {result.Points} instead.");
        }
    }
}
