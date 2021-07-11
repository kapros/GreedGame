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
        public void Min_value_is_1()
        {
            const int minValue = 1;

            var dice = new RegularDice();

            dice.MinValue.Should().Be(minValue);
        }

        [Fact]
        public void Max_value_is_6()
        {
            const int maxValue = 6;

            var dice = new RegularDice();

            dice.MaxValue.Should().Be(maxValue);
        }

        [Fact]
        public void Actual_value_returned()
        {
            const int value = 4;

            var dice = new RegularDice(RegularDiceResult.Four);

            dice.Value.Should().Be(value);
        }
    }
}
