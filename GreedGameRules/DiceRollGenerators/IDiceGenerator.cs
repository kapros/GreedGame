namespace GreedGameRules.DiceRollGenerators
{
    public interface IDiceGenerator
    {
        DiceRoll Roll();

        DiceRoll RerollAll();

        DiceRoll RerollDiceOne(DiceRoll diceRoll);

        DiceRoll RerollDiceTwo(DiceRoll diceRoll);

        DiceRoll RerollDiceThree(DiceRoll diceRoll);

        DiceRoll RerollDiceFour(DiceRoll diceRoll);

        DiceRoll RerollDiceFive(DiceRoll diceRoll);

        DiceRoll RerollMany(DiceRoll diceRoll, int[] indexes);
    }
}
