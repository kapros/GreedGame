using GreedGameRules.DiceProviders;
using GreedGameRules.DiceRollGenerators;
using Xunit;

namespace GreedGameRules.Tests.IntegrationTests
{
    public class DiceGenerator
    {
        [Fact]
        public void RollsFiveDice()
        {
            var sut = new DiceRollGenerator(new DiceProvider()).Roll();

            Assert.True(sut.AllDice.Length == 5);
        }

        [Fact]
        public void RerollsDiceOne()
        {
            var sut = new DiceRollGenerator(new DiceProvider());
            var diceRoll = sut.Roll();

            var newRoll = sut.RerollDiceOne(diceRoll);

            Assert.True(diceRoll != newRoll);
        }
    }
}
