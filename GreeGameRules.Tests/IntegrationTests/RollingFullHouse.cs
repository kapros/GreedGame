using GreedGameRules;
using GreedGameRules.DiceProviders;
using GreedGameRules.DiceRollGenerators;
using GreeGameRules.Tests.CommonData;
using Xunit;

namespace GreeGameRules.Tests.IntegrationTests
{
    public class RollingFullHouse : FullHouseTests
    {
        [Fact]
        public void Awards2500Pts()
        {
            var diceProvider = new MockDiceProvider(new DieRoll[] { DieRoll.Five, DieRoll.Five, DieRoll.Five, DieRoll.Two, DieRoll.Two });
            var diceProc = new RulesProcessor(diceProvider);
            var diceGen = new DiceRollGenerator(diceProvider);
            var roll = diceGen.Roll();
            var result = diceProc.CheckRollResult(roll);

            Assert.True(result.Points == _points, $"Awarded {result.Points} instead of {_points}.");
        }

        [Theory]
        [InlineData(new DieRoll[] { DieRoll.Five, DieRoll.Five, DieRoll.Five, DieRoll.Two, DieRoll.Two }, true)]
        [InlineData(new DieRoll[] { DieRoll.Five, DieRoll.Five, DieRoll.Five, DieRoll.Two, DieRoll.One }, false)]
        public void OccursWhenTwoDiceAreTheSameAndThreeDifferentDiceAreTheSame(DieRoll[] dice, bool isFullHouse)
        {
            var diceProvider = new MockDiceProvider(dice);
            var diceProc = new RulesProcessor(diceProvider);
            var diceGen = new DiceRollGenerator(diceProvider);
            var roll = diceGen.Roll();

            var result = diceProc.CheckRollResult(roll);

            Assert.True((result.DiceCombination == _combination) == isFullHouse, $"Expected {_combination} combination, but got {result.DiceCombination} instead.");
        }

    }
}
