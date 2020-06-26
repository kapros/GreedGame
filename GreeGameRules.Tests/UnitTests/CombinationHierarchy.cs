using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GreedGameRules.Tests.UnitTests
{
    public class CombinationHierarchy
    {
        [Fact]
        [Trait("Unit", "Dice combination")]
        public void NoneIsLowest()
        {
            Assert.True((Enum.GetValues(typeof(DiceCombination))).Cast<int>().OrderBy(x => x).Skip(1).All(x => x > 0));
        }

        [Fact]
        [Trait("Unit", "Dice combination")]
        public void PairIsBetterThanNone()
        {
            Assert.True(DiceCombination.Pair > DiceCombination.None);
        }

        [Fact]
        [Trait("Unit", "Dice combination")]
        public void ThreeOfAKindIsBetterThanPair()
        {
            Assert.True(DiceCombination.ThreeOfAKind > DiceCombination.Pair);
        }

        [Fact]
        [Trait("Unit", "Dice combination")]
        public void FourOfAKindIsBetterThanThreeOfAKind()
        {
            Assert.True(DiceCombination.FourOfAKind > DiceCombination.ThreeOfAKind);
        }

        [Fact]
        [Trait("Unit", "Dice combination")]
        public void FiveOfAKindIsBetterThanFourOfAKind()
        {
            Assert.True(DiceCombination.FiveOfAKind > DiceCombination.FourOfAKind);
        }

        [Fact]
        [Trait("Unit", "Dice combination")]
        public void LowStraightIsBetterThanFiveOfAKind()
        {
            Assert.True(DiceCombination.StraightLow > DiceCombination.FiveOfAKind);
        }

        [Fact]
        [Trait("Unit", "Dice combination")]
        public void HighStraightIsBetterThanLowStraight()
        {
            Assert.True(DiceCombination.StraightHigh > DiceCombination.StraightLow);
        }

        [Fact]
        [Trait("Unit", "Dice combination")]
        public void FullHouseIsBetterThanHighStraight()
        {
            Assert.True(DiceCombination.FullHouse > DiceCombination.StraightHigh);
        }

        [Fact]
        [Trait("Unit", "Dice combination")]
        public void LazyAssTest()
        {
            DiceCombination previous = DiceCombination.None;
            foreach (var combination in (Enum.GetValues(typeof(DiceCombination))).Cast<int>().Where(x => x > 0).OrderBy(x => x))
            {
                Assert.True(combination > (int)previous);
                previous = (DiceCombination)combination;
            }
        }
    }
}
