using Dice.DiceTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice.DiceProviders
{
    public class RegularDiceProvider
    {
        public IEnumerable<RegularDie> RollDice(int diceToReturn)
        {
            return Enumerable.Repeat(RegularDie.FromDiceRoll(RegularDieResult.Five), diceToReturn);
        }
    }
}
