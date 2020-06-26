using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreedGameRules.Rules
{
    public class FiveOfAKindRule : IDiceRule
    {
        private const int _points = 1500;

        public DieRollResult CountPoints(DiceRoll diceRoll)
        {
            if (IsApplicable(diceRoll))
                return new DieRollResult(DiceCombination.FiveOfAKind, _points);
            return DieRollResult.Default();
        }

        public bool IsApplicable(DiceRoll diceRoll)
        {
            return diceRoll.AllDice.Distinct().Count() == 1;
        }
    }
}
