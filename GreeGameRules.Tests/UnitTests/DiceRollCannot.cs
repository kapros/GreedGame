using GreedGameRules.DiceProviders;
using GreedGameRules.DiceRollGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GreedGameRules.Tests.UnitTests
{
    public class DiceRollCannot
    {
        private readonly DiceRoll _diceRoll;

        public DiceRollCannot()
        {
            _diceRoll = new DiceRoll(Enumerable.Range(1, 5).ToArray());
        }

        [Fact]
        [Trait("Unit", "Dice roll")]
        public void BeAccessedWith0Indexer()
        {
            Assert.Throws<IndexOutOfRangeException>(() => _diceRoll[0]);
        }

        [Theory]
        [MemberData(nameof(DataForNegative))]
        [Trait("Unit", "Dice roll")]
        public void BeAccessedWith6OrhigherIndexer(int noOfDice)
        {
            Assert.Throws<IndexOutOfRangeException>(() => _diceRoll[noOfDice]);
        }

        [Fact]
        [Trait("Unit", "Dice generator")]
        public void BeRerolledWith0Dice()
        {
            var diceGen = new DiceRollGenerator(new MockDiceProvider(_diceRoll.AllDice));
            Assert.Throws<IndexOutOfRangeException>(() => diceGen.RerollMany(_diceRoll, new int[0]));
        }

        [Theory]
        [MemberData(nameof(DataForNegative))]
        [Trait("Unit", "Dice generator")]
        public void BeRerolledWithMoverThan5Dice(int noOfDice)
        {
            var diceGen = new DiceRollGenerator(new MockDiceProvider(_diceRoll.AllDice));
            Assert.Throws<IndexOutOfRangeException>(() => diceGen.RerollMany(_diceRoll, Enumerable.Range(1, noOfDice).ToArray()));
        }

        [Theory]
        [MemberData(nameof(DataForPositive))]
        [Trait("Unit", "Dice roll")]
        public void SayTwoRollsAreEqualIfAtLeastOneDieIsDifferent(int noOfDie)
        {
            var left = _diceRoll;
            var rightSideRoll = Enumerable.Range(1, 5).ToArray();
            var proposedReplacement = new Random().Next(1, 6);
            rightSideRoll[noOfDie] = proposedReplacement == rightSideRoll[noOfDie] ? proposedReplacement : new Random().Next(1, 6); // what is the worst that can happen?
            var right = new DiceRoll(rightSideRoll);

            Assert.NotEqual<DiceRoll>(left, right);
            Assert.True(left != right);
        }

        public static readonly IEnumerable<object[]> DataForPositive = new List<object[]>()
        {
        new object[] { 0 },
        new object[] { 1 },
        new object[] { 2 },
        new object[] { 3 },
        new object[] { 4 }
        };

        public static readonly IEnumerable<object[]> DataForNegative = new List<object[]>()
        {
        new object[] { 6 },
        new object[] { 7 },
        new object[] { 8 },
        new object[] { 9 }
        };
    }
}
