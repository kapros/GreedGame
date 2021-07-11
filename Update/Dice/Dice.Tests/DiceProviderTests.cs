using Dice.DiceProviders;
using Dice.DiceTypes;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Dice.Tests
{
    public class DiceProviderTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(6)]
        public void Should_return_correct_amount_of_dice(int diceToReturn)
        {
            var provider = new RegularDiceProvider();
            var dice = provider.RollDice(diceToReturn);
            dice.Should().HaveCount(diceToReturn);
        }

        [Fact]
        public void Should_return_correct_type_of_die()
        {
            var provider = new RegularDiceProvider();
            var dice = provider.RollDice(1);
            dice.First().Should().BeOfType(typeof(RegularDie));
        }

        [Fact]
        public void Should_return_different_results()
        {
            var provider = new RegularDiceProvider();
            var dice = provider.RollDice(6);
            dice.Distinct().Should().HaveCountGreaterOrEqualTo(2);
        }
    }
}
