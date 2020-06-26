namespace GreedGameRules.DiceProviders
{
    public interface IDiceProvider
    {
        DieRoll[] RollAllFiveDice();
        DieRoll RollDiceOne();
        DieRoll RollDiceTwo();
        DieRoll RollDiceThree();
        DieRoll RollDiceFour();
        DieRoll RollDiceFive();
    }
}