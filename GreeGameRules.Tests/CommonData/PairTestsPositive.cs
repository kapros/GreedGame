namespace GreedGameRules.Tests.CommonData
{
    public class PairTestsPositive
    {
        internal const DiceCombination _combination = DiceCombination.Pair;
        internal const int _onesPoints = 200;
        internal const int _fivesPoints = 100;

        internal static readonly DieRoll[] _pairOfOnes = new DieRoll[] { DieRoll.One, DieRoll.One, DieRoll.Four, DieRoll.Six, DieRoll.Three };
        internal static readonly DieRoll[] _pairOfFives = new DieRoll[] { DieRoll.Five, DieRoll.Five, DieRoll.Four, DieRoll.Six, DieRoll.Three };
    }
}
