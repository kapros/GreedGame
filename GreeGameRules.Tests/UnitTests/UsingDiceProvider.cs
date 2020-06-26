using GreedGameRules;
using GreedGameRules.DiceProviders;
using Xunit;
using System.Linq;
using System.Collections.Generic;
using GreedGameRules.DiceRollGenerators;

namespace GreeGameRules.Tests.UnitTests
{
    public class UsingDiceProvider
    {
        private const int _min = 1;
        private const int _max = 6;

        [Trait("Unit", "Dice provider")]
        [Fact]
        public void ShouldCreateNumbersWithin1And6ForAllDice()
        {
            var listOfRolls = new List<int[]>();
            var diceGen = new DiceRollGenerator(new DiceProvider());

            for (int i = 0; i < 100; i++)
            {
                listOfRolls.Add(diceGen.Roll().AllDice.ToIntArray());
            }

            Assert.True(listOfRolls.All(x => x.All(y => y >= _min && y <= _max )));
        }

    }
}
