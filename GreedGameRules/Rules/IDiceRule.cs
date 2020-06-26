using System;
using System.Collections.Generic;
using System.Text;

namespace GreedGameRules
{
    public interface IDiceRule
    {
        DieRollResult CountPoints(DiceRoll diceRoll);
        bool IsApplicable(DiceRoll diceRoll);
    }
}
