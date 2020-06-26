using GreedGameRules.DiceProviders;
using GreedGameRules.DiceRollGenerators;
using GreedGameRules.Tests.CommonData;
using Xunit;

namespace GreedGameRules.Tests.IntegrationTests
{
    public class RollingThreeOfAKind : ThreeOfAKindTestsPositive
    {
        [Fact]
        public void Awards100PtsMultipliedByTheDieValue()
        {
            int expectedPoints = _pointsBase * 5;
            var diceProvider = new MockDiceProvider(new DieRoll[] { DieRoll.Five, DieRoll.Five, DieRoll.Five, DieRoll.One, DieRoll.Two });
            var diceProc = new RulesProcessor(diceProvider);
            var diceGen = new DiceRollGenerator(diceProvider);
            var roll = diceGen.Roll();

            var result = diceProc.CheckRollResult(roll);

            Assert.True(result.Points == expectedPoints, $"Awarded {result.Points} instead of {expectedPoints}.");
        }

        [Fact]
        public void Awards1000PtsIfThreeOnesAreRolled()
        {
            int expectedPoints = 1000;
            var diceProvider = new MockDiceProvider(new DieRoll[] { DieRoll.One, DieRoll.One, DieRoll.One, DieRoll.Three, DieRoll.Two });
            var diceProc = new RulesProcessor(diceProvider);
            var diceGen = new DiceRollGenerator(diceProvider);
            var roll = diceGen.Roll();

            var result = diceProc.CheckRollResult(roll);

            Assert.True(result.Points == expectedPoints, $"Awarded {result.Points} instead of {expectedPoints}.");
        }

        [Fact]
        public void Awards500PtsIfThreeFivesAreRolled()
        {
            int expectedPoints = 500;
            var diceProvider = new MockDiceProvider(new DieRoll[] { DieRoll.Five, DieRoll.Five, DieRoll.Five, DieRoll.Three, DieRoll.Two });
            var diceProc = new RulesProcessor(diceProvider);
            var diceGen = new DiceRollGenerator(diceProvider);
            var roll = diceGen.Roll();

            var result = diceProc.CheckRollResult(roll);

            Assert.True(result.Points == expectedPoints, $"Awarded {result.Points} instead of {expectedPoints}.");
        }

        [Fact]
        public void OccursWhenRollingThreeOfTheSameDie()
        {
            var diceProvider = new MockDiceProvider(new DieRoll[] { DieRoll.Five, DieRoll.Five, DieRoll.Five, DieRoll.One, DieRoll.Two });
            var diceProc = new RulesProcessor(diceProvider);
            var diceGen = new DiceRollGenerator(diceProvider);
            var roll = diceGen.Roll();

            var result = diceProc.CheckRollResult(roll);

            Assert.True(result.DiceCombination == _combination, $"Expected {_combination} combination, but got {result.DiceCombination} instead.");
        }

        [Theory]
        [InlineData(new DieRoll[] { DieRoll.Five, DieRoll.Five, DieRoll.Five, DieRoll.Five, DieRoll.Two }, DiceCombination.FourOfAKind)]
        [InlineData(new DieRoll[] { DieRoll.Five, DieRoll.Five, DieRoll.Five, DieRoll.Five, DieRoll.Five }, DiceCombination.FiveOfAKind)]
        public void DoesNotOccurWhenRollingFourOrMoreOfTheSameDie(DieRoll[] dice, DiceCombination diceCombination)
        {
            var diceProvider = new MockDiceProvider(dice);
            var diceProc = new RulesProcessor(diceProvider);
            var diceGen = new DiceRollGenerator(diceProvider);
            var roll = diceGen.Roll();

            var result = diceProc.CheckRollResult(roll);

            Assert.True(result.DiceCombination == diceCombination, $"Expected {diceCombination} combination, but got {result.DiceCombination} instead.");
        }

        [Fact]
        public void DoesNotOccurWhenRollingAPair()
        {
            var diceProvider = new MockDiceProvider(new DieRoll[] { DieRoll.Five, DieRoll.Five, DieRoll.Six, DieRoll.One, DieRoll.Two });
            var diceProc = new RulesProcessor(diceProvider);
            var diceGen = new DiceRollGenerator(diceProvider);
            var roll = diceGen.Roll();

            var result = diceProc.CheckRollResult(roll);

            Assert.True(result.DiceCombination != _combination, $"Expected combination different from {_combination}, but got {result.DiceCombination} instead.");
        }
    }
}
