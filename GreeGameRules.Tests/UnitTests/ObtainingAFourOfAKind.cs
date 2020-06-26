using GreedGameRules;
using GreedGameRules.DiceProviders;
using GreedGameRules.Rules;
using GreeGameRules.Tests.ClassData;
using GreeGameRules.Tests.CommonData;
using Xunit;

namespace GreeGameRules.Tests.UnitTests
{
    public class ObtainingAFourOfAKind : FourOfAKindTests
    {
        [Trait("Unit", "Four of a kind")]
        [Theory]
        [ClassData(typeof(FourOfAKindClassData))]
        public void CanBeAchievedByFourOfAnyRoll(DieRoll dice)
        {
            var diceSet = FakeDiceRollFactory.GetSetOfRolls(dice, 4);
            var fourOfAKind = new FourOfAKindRule();

            var result = fourOfAKind.CountPoints(new DiceRoll(diceSet));

            Assert.True(result.DiceCombination == _combination);
        }

        [Trait("Unit", "Four of a kind")]
        [Theory]
        [ClassData(typeof(FourOfAKindClassData))]
        public void Awards1000PtsForAllRolls(DieRoll dice)
        {
            var diceSet = FakeDiceRollFactory.GetSetOfRolls(dice, 4);
            var fourOfAKind = new FourOfAKindRule();

            var result = fourOfAKind.CountPoints(new DiceRoll(diceSet));

            Assert.True(result.Points == _points);
        }
    }
}
