using GreedGameRules;
using GreedGameRules.DiceProviders;
using GreedGameRules.DiceRollGenerators;
using Xunit;

namespace GreeGameRules.Tests.IntegrationTests
{
    public class RollingLowStraight
    {
        private const int _expected = 2000;
        private const DiceCombination _combination = DiceCombination.StraightLow;

        [Fact]
        public void Awards2000Pts()
        {
            var diceProvider = new MockDiceProvider(new DieRoll[] { DieRoll.One, DieRoll.Two, DieRoll.Four, DieRoll.Three, DieRoll.Five });
            var diceProc = new RulesProcessor(diceProvider);
            var diceGen = new DiceRollGenerator(diceProvider);
            var roll = diceGen.Roll();

            var result = diceProc.CheckRollResult(roll);

            Assert.True(result.Points == _expected, $"Awarded {result.Points} instead of {_expected}.");
        }

        [Theory]
        [InlineData(new DieRoll[] { DieRoll.One, DieRoll.Two, DieRoll.Four, DieRoll.Three, DieRoll.Five }, true)]
        [InlineData(new DieRoll[] { DieRoll.Six, DieRoll.Two, DieRoll.Four, DieRoll.Three, DieRoll.Five }, false)]
        public void OnlyHappensWhenRollingOneThroughFive(DieRoll[] dice, bool isLowStraight)
        {
            var diceProvider = new MockDiceProvider(dice);
            var diceProc = new RulesProcessor(diceProvider);
            var diceGen = new DiceRollGenerator(diceProvider);
            var roll = diceGen.Roll();

            var result = diceProc.CheckRollResult(roll);

            Assert.True((result.DiceCombination == _combination) == isLowStraight, $"Expected {_combination} combination, but got {result.DiceCombination} instead.");
        }
    }
}
