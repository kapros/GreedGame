using GreedGameRules;
using GreedGameRules.DiceProviders;
using GreedGameRules.DiceRollGenerators;
using GreeGameRules.Tests.CommonData;
using Xunit;

namespace GreeGameRules.Tests.IntegrationTests
{
    public class RollingHighStraight : HighStraightTestsPositive
    {
        [Fact]
        public void Awards2000Pts()
        {
            var diceProvider = new MockDiceProvider(new DieRoll[] { DieRoll.Six, DieRoll.Two, DieRoll.Four, DieRoll.Three, DieRoll.Five });
            var diceProc = new RulesProcessor(diceProvider);
            var diceGen = new DiceRollGenerator(diceProvider);
            var roll = diceGen.Roll();

            var result = diceProc.CheckRollResult(roll);

            Assert.True(result.Points == _points, $"Awarded {result.Points} instead of {_points}.");
        }

        [Theory]
        [InlineData(new DieRoll[] { DieRoll.One, DieRoll.Two, DieRoll.Four, DieRoll.Three, DieRoll.Five }, false)]
        [InlineData(new DieRoll[] { DieRoll.Six, DieRoll.Two, DieRoll.Four, DieRoll.Three, DieRoll.Five }, true)]
        public void OnlyHappensWhenRollingTwoThroughSix(DieRoll[] dice, bool isHighStraight)
        {
            var diceProvider = new MockDiceProvider(dice);
            var diceProc = new RulesProcessor(diceProvider);
            var diceGen = new DiceRollGenerator(diceProvider);
            var roll = diceGen.Roll();

            var result = diceProc.CheckRollResult(roll);

            Assert.True((result.DiceCombination == _combination) == isHighStraight, $"Expected {_combination} combination, but got {result.DiceCombination} instead.");
        }
    }
}
