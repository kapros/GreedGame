using GreedGameRules;
using GreedGameRules.DiceProviders;
using System.Linq;
using Xunit;

namespace GreeGameRules.Tests
{
    public class FakeDiceRollFactoryTests
    {
        [Fact]
        public void FakeDiceRollFactoryReturnsArrayOfDice()
        {
            var diceSet = FakeDiceRollFactory.GetSetOfRolls(DieRoll.Five, 3);
            var fakeDice = new MockDiceProvider(diceSet).RollAllFiveDice();

            Assert.True(diceSet.Length == 5);
            Assert.True(diceSet.Take(3).All(x => x == DieRoll.Five));
            Assert.True(diceSet.Skip(3).All(x => x != DieRoll.Five));
            Assert.True(fakeDice.All(x => ((int)x).Between(1, 6)));
        }
    }
}
