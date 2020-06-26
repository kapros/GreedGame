namespace GreedGameRules.DiceProviders
{
    public class MockDiceProvider : IDiceProvider
    {
        public DieRoll DiceOne = 0;
        public DieRoll DiceTwo = 0;
        public DieRoll DiceThree = 0;
        public DieRoll DiceFour = 0;
        public DieRoll DiceFive = 0;

        public MockDiceProvider(DieRoll[] rolls)
        {
            try
            {
                DiceOne = rolls[0];
                DiceTwo = rolls[1];
                DiceThree = rolls[2];
                DiceFour = rolls[3];
                DiceFive = rolls[4];
            }
            catch
            {// swallow exception as this is just a mock for testing purposes
            }
        }

        public DieRoll[] RollAllFiveDice() => new DieRoll[5]
        {
            DiceOne,
            DiceTwo,
            DiceThree,
            DiceFour,
            DiceFive
        };

        public DieRoll RollDiceFive() => DiceFive;

        public DieRoll RollDiceFour() => DiceFour;

        public DieRoll RollDiceOne() => DiceOne;

        public DieRoll RollDiceThree() => DiceThree;

        public DieRoll RollDiceTwo() => DiceTwo;
    }
}
