using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice
{
    public class RegularDice
    {
        private RegularDice()
        {
        }

        public RegularDice(RegularDiceResult result)
        {
            Value = result;
        }

        public RegularDiceResult Value { get; }
    }
}
