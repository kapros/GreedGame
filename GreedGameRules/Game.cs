using GreedGameRules.DiceProviders;
using GreedGameRules.DiceRollGenerators;

namespace GreedGameRules
{
    public class Game
    {
        private readonly RulesProcessor _rulesProcessor;
        private readonly IDiceGenerator _diceGenerator;
        private readonly IDiceProvider _diceProvider;


        public Game(IDiceGenerator diceGenerator, IDiceProvider diceProvider)
        {
            _diceGenerator = diceGenerator;
            _diceProvider = diceProvider;
            _rulesProcessor = new RulesProcessor(_diceProvider);
        }

        public DieRollResult Result { get; private set; }

        public DiceRoll Roll { get; private set; }

        public void RollTheDice()
        {
            Roll = _diceGenerator.Roll();
        }

        public (DiceCombination Combination, int Points) CheckTheResult()
        {
            Result = _rulesProcessor.CheckRollResult(Roll);
            return (Result.DiceCombination, Result.Points);
        }
    }
}
