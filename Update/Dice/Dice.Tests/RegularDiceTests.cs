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
            var minEnumValue = Enum.GetValues(typeof(RegularDiceResult)).Cast<RegularDiceResult>().Min();
            minEnumValue.Should().Be(minValue);
        }

        [Fact]
        public void Max_value_is_6()
        {
            const int maxValue = 6;

            var maxEnumValue = Enum.GetValues(typeof(RegularDiceResult)).Cast<RegularDiceResult>().Max();

            maxEnumValue.Should().Be(maxValue);
        }

        [Fact]
        public void Actual_value_returned()
        {
            const int value = 4;

            var dice = RegularDice.FromDiceRoll(RegularDiceResult.Four);

            dice.Value.Should().Be(value);
        }

        [Fact]
        public void Is_not_equal_to_another_regular_die_with_different_value()
        {
            const RegularDiceResult value = RegularDiceResult.Four;

            var dice = RegularDice.FromDiceRoll(value);
            var other = RegularDice.FromDiceRoll(RegularDiceResult.Three);

            dice.Equals(other).Should().BeFalse();
        }

        [Fact]
        public void Is_not_equal_to_another_regular_die_with_same_value()
        {
            const RegularDiceResult value = RegularDiceResult.Four;

            var dice = RegularDice.FromDiceRoll(value);
            var other = RegularDice.FromDiceRoll(value);

            dice.Equals(other).Should().BeTrue();
        }

        [Fact]
        public void Has_same_hash_code_for_same_value_objects()
        {
            const RegularDiceResult value = RegularDiceResult.Four;

            var dice = RegularDice.FromDiceRoll(value);
            var other = RegularDice.FromDiceRoll(value);

            dice.GetHashCode().Should().Be(other.GetHashCode());
        }


    }
}
