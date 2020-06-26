using System;
using System.Collections.Generic;
using System.Linq;

namespace GreedGameRules.Rules
{
    public class StraightRule : IDiceRule
    {
        private const int _points = 2000;

        public DieRollResult CountPoints(DiceRoll diceRoll)
        {
            var dice = diceRoll.AllDice.ToIntArray().OrderBy(x => x).ToArray();
            if (dice.Distinct().Count() != 5)
                return DieRollResult.Default();
            else
            {
                if (dice.Any((x => x == (int)DieRoll.One)) && IsSequenceConsecutive(dice))
                    return new DieRollResult(DiceCombination.StraightLow, _points);
                else if (IsSequenceConsecutive(dice))
                    return new DieRollResult(DiceCombination.StraightHigh, _points);
                else
                    return DieRollResult.Default();
            }
        }

        public bool IsApplicable(DiceRoll diceRoll)
        {
            throw new NotImplementedException();
        }

        private bool IsSequenceConsecutive(int[] dice)
        {
            var min = dice.Min();
            var max = dice.Max();
            var all = Enumerable.Range(min, max - min + 1).ToArray();
            return dice.SequenceEqual(all);
        }
    }
}
