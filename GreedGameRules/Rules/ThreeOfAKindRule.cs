using System.Linq;

namespace GreedGameRules.Rules
{
    public class ThreeOfAKindRule : IDiceRule
    {
        private const int _pointsBase = 100;
        private const int _onesRulePoints = 1000;
        private const int _fivesRulePoints = 500;

        public DieRollResult CountPoints(DiceRoll diceRoll)
        {
            if (IsApplicable(diceRoll))
                return new DieRollResult(DiceCombination.ThreeOfAKind, GetPoints(diceRoll));
            else
                return DieRollResult.Default();
        }

        private int GetPoints(DiceRoll diceRoll)
        {
            var dominantDie = GetDominantDie(diceRoll);
            if (dominantDie == DieRoll.One)
                return _onesRulePoints;
            if (dominantDie == DieRoll.Five)
                return _fivesRulePoints;
            return _pointsBase * (int)dominantDie;
        }

        public bool IsApplicable(DiceRoll diceRoll)
        {
            return diceRoll.AllDice.GroupBy(x => x).Any(x => x.Count() == 3);
        }

        public DieRoll GetDominantDie(DiceRoll diceRoll)
        {
            var groupped = diceRoll.AllDice.ToIntArray().GroupBy(x => x);
            var ordered = groupped.OrderByDescending(x => x.Count());
            return (DieRoll)ordered.First().First();
        }
    }
}
