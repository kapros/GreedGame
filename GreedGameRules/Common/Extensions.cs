using System;
using System.Collections.Generic;
using System.Linq;

namespace GreedGameRules
{
    public static class Extensions
    {
        public static string Name(this DiceCombination combination)
        {
            var attribute = combination
                .GetType()
                .GetMember(combination.ToString())[0]
                .GetCustomAttributes(typeof(DisplayAttribute), false)[0] as DisplayAttribute;
            return attribute.ToString();
        }

        /// <summary>
        /// Checks whether the integer is between the specified numbers, with the range being inclusive.
        /// </summary>
        public static bool Between(this int integer, int min, int max)
        {
            return integer >= Math.Min(min, max) && integer <= Math.Max(max, min);
        }

        public static int[] ToIntArray(this DieRoll[] rolls)
        {
            return rolls.Select(x => (int)x).ToArray();
        }

        public static DieRoll[] ToDiceArray(this int[] ints)
        {
            return ints.Select(x => (DieRoll)x).ToArray();
        }
    }
}
