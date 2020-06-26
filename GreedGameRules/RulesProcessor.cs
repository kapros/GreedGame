using GreedGameRules.DiceProviders;
using GreedGameRules.Rules;
using System.Collections.Generic;

namespace GreedGameRules
{
    public class RulesProcessor
    {
        private IDiceProvider _diceProvider;
        private List<IDiceRule> _rules;

        public RulesProcessor(IDiceProvider diceProvider)
        {
            _diceProvider = diceProvider;
            _rules = new List<IDiceRule>()
            {
                new FullHouseRule(),
                new StraightRule(),
                new FiveOfAKindRule(),
                new FourOfAKindRule(),
                new ThreeOfAKindRule(),
                new PairRule(),
            };
        }

        public DieRollResult CheckRollResult(DiceRoll roll)
        {
            DieRollResult result = DieRollResult.Default();
            foreach (var rule in _rules)
            {
                result = DieRollResult.Max(result, rule.CountPoints(roll));
            }
            return result;
        }
    }
}
