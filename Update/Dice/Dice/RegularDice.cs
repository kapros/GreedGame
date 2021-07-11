using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice
{
    public class RegularDice
    {
        public RegularDice()
        {
        }

        public RegularDice(RegularDiceResult result)
        {
            Value = result;
        }

        public int MaxValue => 6;

        public int MinValue => 1;

        public RegularDiceResult Value { get; }
    }
}
