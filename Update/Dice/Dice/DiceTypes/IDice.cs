namespace Dice.DiceTypes
{
    public interface IDie<T>
    {
        T Value { get; }
    }
}