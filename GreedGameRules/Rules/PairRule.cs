using System.Linq;

namespace GreedGameRules.Rules
{
    public class PairRule : IDiceRule
    {
        private const int _pointsForPairOfOnes = 200;
        private const int _pointsForPairOfFives = 100;
        private const DiceCombination _pair = DiceCombination.Pair;
        private const DiceCombination _twoPair = DiceCombination.TwoPair;

        public DieRollResult CountPoints(DiceRoll diceRoll)
        {
            if (!IsApplicable(diceRoll))
                return DieRollResult.Default();
            return Combination(diceRoll);
        }

        private DieRollResult Combination(DiceRoll diceRoll)
        {
            var onesOrFives = OnesOrFives(diceRoll);
            var combination = onesOrFives.pairOfOnes ^ onesOrFives.pairOfFives ? _pair : _twoPair;
            return new DieRollResult(combination, GetPoints(onesOrFives));
        }

        private (bool pairOfOnes, bool pairOfFives) OnesOrFives(DiceRoll diceRoll)
        {
            bool pairOfOnes = diceRoll.AllDice.Count(x => x == DieRoll.One) == 2;
            bool pairOfFives = diceRoll.AllDice.Count(x => x == DieRoll.Five) == 2;
            return (pairOfOnes, pairOfFives);
        }

        private int GetPoints((bool pairOfOnes, bool pairOfFives) combinations)
        {
            int total = 0;
            if (combinations.pairOfOnes)
                total += _pointsForPairOfOnes;
            if (combinations.pairOfFives)
                total += _pointsForPairOfFives;
            return total;
        }

        public bool IsApplicable(DiceRoll diceRoll)
        {
            var values = diceRoll.AllDice;
            if (!values.Any(x => x == DieRoll.One || x == DieRoll.Five))
                return false;
            var ones = values.Where(x => x == DieRoll.One);
            var fives = values.Where(x => x == DieRoll.Five);
            if (diceRoll.AllDice.Count(x => x == DieRoll.One) != 2 && diceRoll.AllDice.Count(x => x == DieRoll.Five) != 2)
                return false;
            return true;
        }
    }
}
