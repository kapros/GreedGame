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
    public class RegularDieTests
    {
        [Fact]
        public void Min_value_is_1()
        {
            const int minValue = 1;
            var minEnumValue = Enum.GetValues(typeof(RegularDieResult)).Cast<RegularDieResult>().Min();
            minEnumValue.Should().Be(minValue);
        }

        [Fact]
        public void Max_value_is_6()
        {
            const int maxValue = 6;

            var maxEnumValue = Enum.GetValues(typeof(RegularDieResult)).Cast<RegularDieResult>().Max();

            maxEnumValue.Should().Be(maxValue);
        }

        [Fact]
        public void Actual_value_returned()
        {
            const int value = 4;

            var dice = RegularDie.FromDiceRoll(RegularDieResult.Four);

            dice.Value.Should().Be(value);
        }

        [Fact]
        public void Is_not_equal_to_another_regular_die_with_different_value()
        {
            const RegularDieResult value = RegularDieResult.Four;

            var dice = RegularDie.FromDiceRoll(value);
            var other = RegularDie.FromDiceRoll(RegularDieResult.Three);

            dice.Equals(other).Should().BeFalse();
        }

        [Fact]
        public void Is_not_equal_to_another_regular_die_with_same_value()
        {
            const RegularDieResult value = RegularDieResult.Four;

            var dice = RegularDie.FromDiceRoll(value);
            var other = RegularDie.FromDiceRoll(value);

            dice.Equals(other).Should().BeTrue();
        }

        [Fact]
        public void Has_same_hash_code_for_same_value_objects()
        {
            const RegularDieResult value = RegularDieResult.Four;

            var dice = RegularDie.FromDiceRoll(value);
            var other = RegularDie.FromDiceRoll(value);

            dice.GetHashCode().Should().Be(other.GetHashCode());
        }

        [Fact]
        public void Has_same_hash_code_for_different_value_objects()
        {
            var dice = RegularDie.FromDiceRoll(RegularDieResult.Four);
            var other = RegularDie.FromDiceRoll(RegularDieResult.One);

            dice.GetHashCode().Should().NotBe(other.GetHashCode());
        }

        [Fact]
        public void Should_return_name_of_die_side()
        {
            var dice = RegularDie.FromDiceRoll(RegularDieResult.Four);

            dice.ToString().Should().Be(RegularDieResult.Four.ToString());
        }
    }
}
