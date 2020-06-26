using GreedGameRules;
using GreedGameRules.DiceProviders;
using GreedGameRules.DiceRollGenerators;
using GreeGameRules.Tests.CommonData;
using Xunit;

namespace GreeGameRules.Tests.IntegrationTests
{
    public class RollingFourOfAKindRule : FourOfAKindTests
    {
        private readonly DieRoll[] _dice = new DieRoll[] { DieRoll.Five, DieRoll.Five, DieRoll.Five, DieRoll.Five, DieRoll.One };

        [Fact]
        public void Awards1000Pts()
        {
            var diceProvider = new MockDiceProvider(_dice);
            var diceProc = new RulesProcessor(diceProvider);
            var diceGen = new DiceRollGenerator(diceProvider);
            var roll = diceGen.Roll();

            var result = diceProc.CheckRollResult(roll);

            Assert.True(result.DiceCombination == _combination, $"Expected {_combination} combination, but got {result.DiceCombination} instead.");
        }

        [Fact]
        public void IsOnlyPossibleIfThereAreFourOfTheSameDie()
        {
            var diceProvider = new MockDiceProvider(_dice);
            var diceProc = new RulesProcessor(diceProvider);
            var diceGen = new DiceRollGenerator(diceProvider);
            var roll = diceGen.Roll();

            var result = diceProc.CheckRollResult(roll);

            Assert.True(result.Points == _points, $"Awarded {result.Points} instead of {_points}.");
        }
    }
}
