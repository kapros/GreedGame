using System.Linq;

namespace GreedGameRules.Rules
{
    public class FourOfAKindRule : IDiceRule
    {
        private const int _points = 1000;

        public DieRollResult CountPoints(DiceRoll diceRoll)
        {
            if (IsApplicable(diceRoll))
                return new DieRollResult(DiceCombination.FourOfAKind, _points);
            else
                return DieRollResult.Default();
        }

        public bool IsApplicable(DiceRoll diceRoll)
        {
            var grouppedResults = diceRoll.AllDice.GroupBy(x => x);
            return grouppedResults.Any(x => x.Count() == 4);
        }
    }
}