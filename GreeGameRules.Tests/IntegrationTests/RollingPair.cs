using GreedGameRules.DiceProviders;
using GreedGameRules.DiceRollGenerators;
using GreedGameRules.Tests.CommonData;
using System.Collections.Generic;
using Xunit;

namespace GreedGameRules.Tests.IntegrationTests
{
    public class RollingPair : PairTestsPositive
    {
        [Fact]
        public void OccursWhenRollingTwoOnes()
        {
    
            IDiceProvider diceProvider = new MockDiceProvider(_pairOfOnes);
            IDiceGenerator diceGen = new DiceRollGenerator(diceProvider);
            RulesProcessor rules = new RulesProcessor(diceProvider);
            var roll = diceGen.Roll();

            var result = rules.CheckRollResult(roll);

            Assert.True(result.DiceCombination == _combination);
        }

        [Fact]
        public void Awards200Pts()
        {
            IDiceProvider diceProvider = new MockDiceProvider(_pairOfOnes);
            IDiceGenerator diceGen = new DiceRollGenerator(diceProvider);
            RulesProcessor rules = new RulesProcessor(diceProvider);
            var roll = diceGen.Roll();

            var result = rules.CheckRollResult(roll);

            Assert.True(result.Points == _onesPoints);
        }

        [Fact]
        public void OccursWhenRollingTwoFives()
        {
            IDiceProvider diceProvider = new MockDiceProvider(_pairOfFives);
            IDiceGenerator diceGen = new DiceRollGenerator(diceProvider);
            RulesProcessor rules = new RulesProcessor(diceProvider);
            var roll = diceGen.Roll();

            var result = rules.CheckRollResult(roll);

            Assert.True(result.DiceCombination == _combination);
        }

        [Fact]
        public void Awards100Pts()
        {
            IDiceProvider diceProvider = new MockDiceProvider(_pairOfFives);
            IDiceGenerator diceGen = new DiceRollGenerator(diceProvider);
            RulesProcessor rules = new RulesProcessor(diceProvider);
            var roll = diceGen.Roll();

            var result = rules.CheckRollResult(roll);

            Assert.True(result.Points == _fivesPoints);
        }
    }

    public class RollingPairDoesNot : PairTestsNegative
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void OccurForNonOneOrNonFiveDice(DieRoll[] dice)
        {
            IDiceProvider diceProvider = new MockDiceProvider(dice);
            IDiceGenerator diceGen = new DiceRollGenerator(diceProvider);
            RulesProcessor rules = new RulesProcessor(diceProvider);
            var roll = diceGen.Roll();

            var result = rules.CheckRollResult(roll);

            Assert.True(result.DiceCombination == _combination);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void AwardPoints(DieRoll[] dice)
        {
            IDiceProvider diceProvider = new MockDiceProvider(dice);
            IDiceGenerator diceGen = new DiceRollGenerator(diceProvider);
            RulesProcessor rules = new RulesProcessor(diceProvider);
            var roll = diceGen.Roll();

            var result = rules.CheckRollResult(roll);

            Assert.True(result.Points == _points);
        }

        public static readonly IEnumerable<object[]> Data = new List<object[]>()
        {
            new object[] { new DieRoll[] { DieRoll.Three, DieRoll.Three, DieRoll.Six, DieRoll.Six, DieRoll.Five }},
            new object[] { new DieRoll[] { DieRoll.Two, DieRoll.Two, DieRoll.Four, DieRoll.Four, DieRoll.Three }},
        };
    }
}
