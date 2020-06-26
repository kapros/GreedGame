using System;
using System.Collections.Generic;
using System.Linq;

namespace GreedGameRules.DiceProviders
{
    public class FakeDiceRollFactory
    {
        public static DieRoll[] FourSixes = new DieRoll[] { DieRoll.Six, DieRoll.Six, DieRoll.Six, DieRoll.Six, DieRoll.One };
        public static DieRoll[] FourFives = new DieRoll[] { DieRoll.Five, DieRoll.Five, DieRoll.Five, DieRoll.Five, DieRoll.One };
        public static DieRoll[] FourFours = new DieRoll[] { DieRoll.Four, DieRoll.Four, DieRoll.Four, DieRoll.Four, DieRoll.One };
        public static DieRoll[] FourThrees = new DieRoll[] { DieRoll.Three, DieRoll.Three, DieRoll.Three, DieRoll.Three, DieRoll.One };
        public static DieRoll[] FourTwos = new DieRoll[] { DieRoll.Two, DieRoll.Two, DieRoll.Two, DieRoll.Two, DieRoll.One };
        public static DieRoll[] FourOnes = new DieRoll[] { DieRoll.One, DieRoll.One, DieRoll.One, DieRoll.One, DieRoll.Six };

        private const int maxDice = 5;

        public static DieRoll[] GetSetOfRolls(DieRoll DieRoll, int repetitions)
        {
            if (repetitions < 1)
                throw new ArgumentException("Idiot, you can't have something repeated {0} times", repetitions.ToString());
          
            if (repetitions > maxDice)
                repetitions = maxDice;
            DieRoll[] rollSet = new DieRoll[5];
            GetRollArray(DieRoll, repetitions).CopyTo(rollSet, 0);
            for (int i = 0; i < repetitions; i++)
            {
                rollSet[i] = DieRoll;
            }
            if (repetitions == maxDice)
                return rollSet;
            for (int i = repetitions; i < maxDice; i++)
            {
                rollSet[i] = (DieRoll)DiceHelper.GetRollExcept(DieRoll);
            }
            return rollSet;
        }

        public static DieRoll[] GetSetOfRolls(params KeyValuePair<DieRoll, int>[] diceRolls)
        {
            int sum = diceRolls.Sum(x => x.Value);
            if (sum > 5)
                throw new ArgumentException("Sum of all repetitions exceeds 5 - you are trying to get a total {0} rolls", sum.ToString());
            DieRoll[] rollSet = new DieRoll[5];
            int idx = 0;
            foreach (var roll in diceRolls)
            {
                GetRollArray(roll.Key, roll.Value).CopyTo(rollSet, idx);
                idx += roll.Value;
            }
            if (idx < 5)
                GetRandomRolls(maxDice - idx, diceRolls.Select(x => x.Key).ToArray()).CopyTo(rollSet, idx);
            return rollSet;
        }

        private static DieRoll[] GetRollArray(DieRoll dieRoll, int repetitions)
        {
            DieRoll[] rollSet = new DieRoll[repetitions];
            for (int i = 0; i < repetitions; i++)
            {
                rollSet[i] = dieRoll;
            }
            return rollSet;
        }

        private static DieRoll[] GetRandomRolls(int repetitions, DieRoll[] except)
        {
            DieRoll[] rollSet = new DieRoll[repetitions];
            for (int i = repetitions; i < maxDice; i++)
            {
                rollSet[i] = (DieRoll)DiceHelper.GetRollExcept(except);
            }
            return rollSet;
        }
    }
}
