using GreedGameRules;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GreeGameRules.Tests.UnitTests
{
    public class DiceRollCanBeInitialized
    {
        [Fact]
        [Trait("Unit", "Dice roll")]
        public void WithAnArrayOfIntegers()
        {
            var integerArray = Enumerable.Range(1, 5).ToArray();

            var roll = new DiceRoll(integerArray);

            Assert.True(roll.AllDice.ToIntArray().SequenceEqual(integerArray));
        }

        [Fact]
        [Trait("Unit", "Dice roll")]
        public void WithAnArrayOfDieRolls()
        {
            var integerArray = Enumerable.Range(1, 5).ToArray();

            var roll = new DiceRoll(integerArray.ToDiceArray());

            Assert.True(roll.AllDice.ToIntArray().SequenceEqual(integerArray));
        }

        [Fact]
        [Trait("Unit", "Dice roll")]
        public void WithAnExistingRollAndANewRoll()
        {
            var integerArray = Enumerable.Range(1, 5).ToArray();
            var newDie = DieRoll.Six;
            var index = 0;
            var oldRoll = new DiceRoll(integerArray.ToDiceArray());
            integerArray[index] = (int)newDie;

            var newRoll = new DiceRoll(oldRoll, newDie, index);

            Assert.True(newRoll.AllDice.ToIntArray().SequenceEqual(integerArray));
        }

        [Fact]
        [Trait("Unit", "Dice roll")]
        public void WithAnExistingRollAndPairsOfNewRolls()
        {
            var integerArray = Enumerable.Range(1, 5).ToArray();
            var firstChange = new KeyValuePair<DieRoll, int>(DieRoll.Six, 0);
            var secondChange = new KeyValuePair<DieRoll, int>(DieRoll.Six, 3);
            var array = new KeyValuePair<DieRoll, int>[] { firstChange, secondChange };
            var oldRoll = new DiceRoll(integerArray.ToDiceArray());
            integerArray[firstChange.Value] = (int)firstChange.Key;
            integerArray[secondChange.Value] = (int)secondChange.Key;

            var newRoll = new DiceRoll(oldRoll, array);

            Assert.True(newRoll.AllDice.ToIntArray().SequenceEqual(integerArray));
        }
    }
}
