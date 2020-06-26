using GreedGameRules.DiceProviders;

namespace GreedGameRules.DiceRollGenerators
{
    public class DiceRollGenerator : IDiceGenerator
    {
        private IDiceProvider _diceProvider;

        public DiceRollGenerator(IDiceProvider diceProvider)
        {
            _diceProvider = diceProvider;
        }

        public DiceRoll RerollAll() => Roll();

        public DiceRoll RerollDiceFive(DiceRoll diceRoll)
        {
            var newFifth = _diceProvider.RollDiceFive();
            return new DiceRoll(new DieRoll[] { diceRoll.DiceOne, diceRoll.DiceTwo, diceRoll.DiceThree, diceRoll.DiceFour, newFifth });
        }

        public DiceRoll RerollDiceFour(DiceRoll diceRoll)
        {
            var newFourth = _diceProvider.RollDiceFour();
            return new DiceRoll(new DieRoll[] { diceRoll.DiceOne, diceRoll.DiceTwo, diceRoll.DiceThree, newFourth, diceRoll.DiceFive });
        }

        public DiceRoll RerollDiceOne(DiceRoll diceRoll)
        {
            var newFirst = _diceProvider.RollDiceOne();
            return new DiceRoll(new DieRoll[] { newFirst, diceRoll.DiceTwo, diceRoll.DiceThree, diceRoll.DiceFour, diceRoll.DiceFive });

        }

        public DiceRoll RerollDiceThree(DiceRoll diceRoll)
        {
            var newThird= _diceProvider.RollDiceThree();
            return new DiceRoll(new DieRoll[] { diceRoll.DiceOne, diceRoll.DiceTwo, newThird, diceRoll.DiceFour, diceRoll.DiceFive });
        }

        public DiceRoll RerollDiceTwo(DiceRoll diceRoll)
        {
            var newSecond = _diceProvider.RollDiceTwo();
            return new DiceRoll(new DieRoll[] { diceRoll.DiceOne, newSecond, diceRoll.DiceThree, diceRoll.DiceFour, diceRoll.DiceFive });

        }

        public DiceRoll RerollMany(DiceRoll diceRoll, int[] indexes)
        {
            if (!indexes.Length.Between(1, 5))
                throw new System.IndexOutOfRangeException($@"Too {(indexes.Length > 5 ? "many" : "few")} dice to reroll.");
            if (indexes.Length == 5)
                return Roll();
            var current = diceRoll.AllDice;
            foreach (var dice in indexes)
            {
                current[dice] = DiceHelper.GetRoll();
            }
            return new DiceRoll(current);
        }
        
        public DiceRoll Roll()
        {
            DieRoll[] roll = _diceProvider.RollAllFiveDice();
            return new DiceRoll(roll);
        }
    }
}
