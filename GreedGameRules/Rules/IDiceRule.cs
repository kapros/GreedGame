namespace GreedGameRules
{
    public interface IDiceRule
    {
        DieRollResult CountPoints(DiceRoll diceRoll);
        bool IsApplicable(DiceRoll diceRoll);
    }
}
