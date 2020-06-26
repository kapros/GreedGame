using GreedGameRules;
using Xunit;

namespace GreeGameRules.Tests.UnitTests
{
    public class ExtensionTests
    {
        [Trait("Unit", "Extensions")]
        [Fact]
        public void DisplayAttribute_ToString_PrintsDisplayValue()
        {
            Assert.True(DiceCombination.FullHouse.Name() == "Full house");
        }

        [Trait("Unit", "Extensions")]
        [Fact]
        public void Between_WithinBorders_True()
        {
            Assert.True(6.Between(5, 7));
        }

        [Trait("Unit", "Extensions")]
        [Fact]
        public void Between_MinBorder_True()
        {
            Assert.True(6.Between(6, 7));
        }

        [Trait("Unit", "Extensions")]
        [Fact]
        public void Between_MaxBorder_True()
        {
            Assert.True(6.Between(1, 6));
        }

        [Trait("Unit", "Extensions")]
        [Fact]
        public void Between_OutsideOfMinBorder_False()
        {
            Assert.False(1.Between(6, 6));
        }

        [Trait("Unit", "Extensions")]
        [Fact]
        public void Between_OutsideOfMaxBorder_False()
        {
            Assert.False(10.Between(6, 6));
        }
    }
}
