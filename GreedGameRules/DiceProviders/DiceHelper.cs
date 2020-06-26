using System;
using System.Linq;

namespace GreedGameRules.DiceProviders
{
    public class DiceHelper
    {
        private const int _min = 1;
        private const int _max = 6;

        internal static DieRoll GetRoll() => (DieRoll)(new Random().Next(_min, _max));

        internal static DieRoll GetRollExcept(int[] exceptThese)
        {
            if (exceptThese.Length == 6)
                throw new ArgumentException("6 constraints provided, random cannot be created");
            int result = 0;
            do
            {
                result = new Random().Next(_min, _max);
            } while (exceptThese.Any(x => result == x));
            return (DieRoll)result;
        }

        internal static DieRoll GetRollExcept(DieRoll[] exceptThese) =>
            GetRollExcept(exceptThese.ToIntArray());

        internal static DieRoll GetRollExcept(int exceptThisOne) =>
            GetRollExcept(new int[] { exceptThisOne });

        internal static DieRoll GetRollExcept(DieRoll exceptThisOne) =>
            GetRollExcept((int)exceptThisOne);

    }
}
