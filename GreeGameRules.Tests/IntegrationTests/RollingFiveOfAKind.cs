using GreedGameRules;
using GreedGameRules.DiceProviders;
using GreedGameRules.DiceRollGenerators;
using GreeGameRules.Tests.CommonData;
using Xunit;

namespace GreeGameRules.Tests.IntegrationTests
{
    public class RollingFiveOfAKind : FiveOfAKindTests
    {
        private readonly IDiceProvider _diceProvider;

        private readonly DieRoll[] _dice = new DieRoll[] { DieRoll.Five, DieRoll.Five, DieRoll.Five, DieRoll.Five, DieRoll.Five };

        public RollingFiveOfAKind()
        {
            _diceProvider = new MockDiceProvider(_dice);
        }

        [Fact]
        public void Awards1500Pts()
        {
            var diceProc = new RulesProcessor(_diceProvider);
            var diceGen = new DiceRollGenerator(_diceProvider);
            var roll = diceGen.Roll();

            var result = diceProc.CheckRollResult(roll);

            Assert.True(result.Points == _points, $"Awarded {result.Points} instead of {_points}.");
        }

        [Fact]
        public void IsOnlyPossibleWhenAllDiceAreTheSame()
        {
            var diceProc = new RulesProcessor(_diceProvider);
            var diceGen = new DiceRollGenerator(_diceProvider);
            var roll = diceGen.Roll();

            var result = diceProc.CheckRollResult(roll);

            Assert.True(result.DiceCombination == _combination, $"Expected {_combination} combination, but got {result.DiceCombination} instead.");
        }

        [Fact]
        public void IsNotAwardedIfAtLeastOneDieIsDifferent()
        {
            var diceProvider = new MockDiceProvider(_dice)
            {
                DiceFive = (DieRoll)1
            };
            var diceProc = new RulesProcessor(diceProvider);
            var diceGen = new DiceRollGenerator(diceProvider);
            var roll = diceGen.Roll();

            var result = diceProc.CheckRollResult(roll);

            Assert.True(result.DiceCombination != _combination, $"Expected non Five of a kind combination, but got {result.DiceCombination} instead.");
        }
    }
}
