namespace Dice.DiceTypes
{
    public interface IDice<T>
    {
        T Value { get; }
    }
}