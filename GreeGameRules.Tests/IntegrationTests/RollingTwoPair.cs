using GreedGameRules.DiceProviders;
using GreedGameRules.DiceRollGenerators;
using GreedGameRules.Tests.CommonData;
using Xunit;

namespace GreedGameRules.Tests.IntegrationTests
{
    public class RollingTwoPair : TwoPairsTestsPositive
    {
        private readonly DieRoll[] dice = new DieRoll[] { DieRoll.One, DieRoll.One, DieRoll.Five, DieRoll.Five, DieRoll.Three };

        [Fact]
        public void OccursWhenRollingTwoOnesAndTwoFives()
        {
            IDiceProvider diceProvider = new MockDiceProvider(dice);
            IDiceGenerator diceGen = new DiceRollGenerator(diceProvider);
            RulesProcessor rules = new RulesProcessor(diceProvider);
            var roll = diceGen.Roll();

            var result = rules.CheckRollResult(roll);

            Assert.True(result.DiceCombination == _combination);
        }

        [Fact]
        public void Awards300Pts()
        {
            IDiceProvider diceProvider = new MockDiceProvider(dice);
            IDiceGenerator diceGen = new DiceRollGenerator(diceProvider);
            RulesProcessor rules = new RulesProcessor(diceProvider);
            var roll = diceGen.Roll();

            var result = rules.CheckRollResult(roll);

            Assert.True(result.Points == _points);
        }
    }
}
