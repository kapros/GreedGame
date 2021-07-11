using Dice.DiceProviders;
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
    }
}
