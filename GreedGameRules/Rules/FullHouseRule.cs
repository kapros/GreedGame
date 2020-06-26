using System.Linq;

namespace GreedGameRules.Rules
{
    public class FullHouseRule : IDiceRule
    {
        private const int _points = 2500;

        public DieRollResult CountPoints(DiceRoll diceRoll)
        {
            if (IsApplicable(diceRoll))
                return new DieRollResult(DiceCombination.FullHouse, _points);
            else
                return DieRollResult.Default();
        }

        public bool IsApplicable(DiceRoll diceRoll)
        {
            var groupped = diceRoll.AllDice.GroupBy(x => x);
            return (groupped.Count() == 2 && (groupped.Any(x => x.Count() == 2 && groupped.Any(y => y.Count() == 3))));
        }
    }
}
