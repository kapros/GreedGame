using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Dice.Tests
{
    public class RegularDiceTests
    {
        [Fact]
        public void Regular_dice_min_value_is_1()
        {
            const int minValue = 1;

            var dice = new RegularDice();

            dice.MinValue.Should().Be(minValue);
        }

        [Fact]
        public void Regular_dice_max_value_is_6()
        {
            const int maxValue = 6;

            var dice = new RegularDice();

            dice.MaxValue.Should().Be(maxValue);
        }
    }
}
