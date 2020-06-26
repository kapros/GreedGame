using GreedGameRules;
using GreedGameRules.DiceProviders;
using GreedGameRules.Rules;
using GreeGameRules.Tests.CommonData;
using System.Collections.Generic;
using Xunit;

namespace GreeGameRules.Tests.UnitTests
{
    public class ObtainingAFullHouse : FullHouseTests
    {
        [Trait("Unit", "Full house")]
        [Theory]
        [MemberData(nameof(Data))]
        public void CanBeDoneThroughRollingAConsecutiveSequence(DieRoll threeDice, DieRoll twoDice)
        {
            KeyValuePair<DieRoll, int> setOfThreeDice = new KeyValuePair<DieRoll, int>(threeDice, 3);
            KeyValuePair<DieRoll, int> setOfTwoDice = new KeyValuePair<DieRoll, int>(twoDice, 2);
            var dice = FakeDiceRollFactory.GetSetOfRolls(setOfThreeDice, setOfTwoDice);

            var result = new FullHouseRule().CountPoints(new DiceRoll(dice));

            Assert.True(result.DiceCombination == _combination, $"Expected {_combination} combination, but got {result.DiceCombination} instead.");
        }

        [Trait("Unit", "Full house")]
        [Theory]
        [MemberData(nameof(Data))]
        public void Awards2500PtsForAllRolls(DieRoll threeDice, DieRoll twoDice)
        {
            KeyValuePair<DieRoll, int> setOfThreeDice = new KeyValuePair<DieRoll, int>(threeDice, 3);
            KeyValuePair<DieRoll, int> setOfTwoDice = new KeyValuePair<DieRoll, int>(twoDice, 2);
            var dice = FakeDiceRollFactory.GetSetOfRolls(setOfThreeDice, setOfTwoDice);

            var result = new FullHouseRule().CountPoints(new DiceRoll(dice));

            Assert.True(result.Points == _points, $"Awarded {result.Points} instead of {_points}.");
        }

        public static readonly IEnumerable<object[]> Data = new List<object[]>()
        {
        new object[] { DieRoll.One, DieRoll.Two },
        new object[] { DieRoll.Two, DieRoll.Three},
        new object[] { DieRoll.Three, DieRoll.Four },
        new object[] { DieRoll.Five, DieRoll.Six },
        new object[] { DieRoll.Six, DieRoll.One},
        new object[] { DieRoll.Four, DieRoll.Five},
        };
    }
}
