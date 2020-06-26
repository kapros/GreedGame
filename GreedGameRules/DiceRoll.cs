using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("GreedGameRules.Tests")]
namespace GreedGameRules
{
    public struct DiceRoll
    {
        public DieRoll DiceOne { get; private set; }
        public DieRoll DiceTwo { get; private set; }
        public DieRoll DiceThree { get; private set; }
        public DieRoll DiceFour { get; private set; }
        public DieRoll DiceFive { get; private set; }
        public DieRoll[] AllDice
        {
            get
            {
                return new DieRoll[]
                {
                    DiceOne, DiceTwo, DiceThree, DiceFour, DiceFive
                };
            }
        }

        internal DieRoll this[int index]
        {
            get
            {
                if (!index.Between(1, 5))
                    throw new System.IndexOutOfRangeException($"{nameof(index)} outside of array bounds");
                switch (index)
                {
                    case 1:
                        return DiceOne;
                    case 2:
                        return DiceTwo;
                    case 3:
                        return DiceThree;
                    case 4:
                        return DiceFour;
                    case 5:
                        return DiceFive;
                    default:
                        throw new System.NotImplementedException();
                }
            }
        }

        internal DiceRoll(DieRoll[] dice) : this(null, null, null, dice)
        {
            DiceOne = dice[0];
            DiceTwo = dice[1];
            DiceThree = dice[2];
            DiceFour = dice[3];
            DiceFive = dice[4];
        }

        internal DiceRoll(int[] dice) : this(dice.ToDiceArray())
        {

        }

        internal DiceRoll(DiceRoll? diceRoll, DieRoll? newDie, int? index, DieRoll[] rolls = null) :
            this(diceRoll, (newDie.HasValue && index.HasValue) ? new KeyValuePair<DieRoll, int>[] { new KeyValuePair<DieRoll, int>(newDie.Value, index.Value) } : new KeyValuePair<DieRoll, int>[0], rolls)
        {

        }

        public DiceRoll(DiceRoll? diceRoll, KeyValuePair<DieRoll, int>[] reroll, DieRoll[] rolls = null)
        {
            DieRoll[] roll = rolls ?? (new DieRoll[5]);
            if (diceRoll != null)
            {
                roll = diceRoll.Value.AllDice;
            }
            if (reroll.Length > 0)
            {
                foreach (var rerolled in reroll)
                {
                    roll[rerolled.Value] = rerolled.Key;
                }
            }
            DiceOne = roll[0];
            DiceTwo = roll[1];
            DiceThree = roll[2];
            DiceFour = roll[3];
            DiceFive = roll[4];
        }

        public override bool Equals(object obj)
        {
            if (obj is DiceRoll roll)
            {
                if (this.AllDice.SequenceEqual(roll.AllDice))
                {
                    if (this[1] != roll[1]) { return false; }
                    if (this[2] != roll[2]) { return false; }
                    if (this[3] != roll[3]) { return false; }
                    if (this[4] != roll[4]) { return false; }
                    if (this[5] != roll[5]) { return false; }
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() + 2137;
        }

        public static bool operator ==(DiceRoll left, DiceRoll right)
        {
            return left.AllDice == right.AllDice;
        }

        public static bool operator !=(DiceRoll left, DiceRoll right) =>
            !(left == right);
    }
}
