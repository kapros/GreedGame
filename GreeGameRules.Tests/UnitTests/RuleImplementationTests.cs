using GreedGameRules.Rules;
using Xunit;

namespace GreedGameRules.Tests.UnitTests
{
    public class RuleImplementationTests
    {
        [Fact]
        [Trait("Unit", "Pair")]
        public void PairRuleImplementsIDiceRule()
        {
            Assert.True((new PairRule()) is IDiceRule);
        }

        [Fact]
        [Trait("Unit", "Three of a kind")]
        public void ThreeOfAKindRuleImplementsIDiceRule()
        {
            Assert.True((new ThreeOfAKindRule()) is IDiceRule);
        }

        [Fact]
        [Trait("Unit", "Four of a kind")]
        public void FourOfAKindRuleImplementsIDiceRule()
        {
            Assert.True((new FourOfAKindRule()) is IDiceRule);
        }

        [Fact]
        [Trait("Unit", "Five of a kind")]
        public void FiveOfAKindRuleImplementsIDiceRule()
        {
            Assert.True((new FiveOfAKindRule()) is IDiceRule);
        }

        [Fact]
        [Trait("Unit", "Straight")]
        public void StraightRuleImplementsIDiceRule()
        {
            Assert.True((new StraightRule()) is IDiceRule);
        }

        [Fact]
        [Trait("Unit", "Full house")]
        public void FullHouseRuleImplementsIDiceRule()
        {
            Assert.True((new FullHouseRule()) is IDiceRule);
        }

    }
}
