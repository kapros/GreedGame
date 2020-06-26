namespace GreedGameRules.DiceProviders
{
    public class DiceProvider : IDiceProvider
    {
        private DieRoll GetRoll()
        {
            return DiceHelper.GetRoll();
        }

        public DieRoll[] RollAllFiveDice()
        {
            return new DieRoll[]
            {
            RollDiceOne(),
            RollDiceTwo(),
            RollDiceThree(),
            RollDiceFour(),
            RollDiceFive()
            };
        }

        public DieRoll RollDiceOne()
        {
            return GetRoll();
        }

        public DieRoll RollDiceFour()
        {
            return GetRoll();
        }

        public DieRoll RollDiceFive()
        {
            return GetRoll();
        }

        public DieRoll RollDiceThree()
        {
            return GetRoll();
        }

        public DieRoll RollDiceTwo()
        {
            return GetRoll();
        }
    }
}
