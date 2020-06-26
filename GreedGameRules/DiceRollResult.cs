namespace GreedGameRules
{
    public class DieRollResult
    {
        public DiceCombination DiceCombination { get; private set; }
        public int Points { get; private set; }

        public DieRollResult(DiceCombination diceCombination, int points)
        {
            DiceCombination = diceCombination;
            Points = points;
        }

        public static DieRollResult Max(DieRollResult first, DieRollResult second)
        {
            // TODO:
            // Create logic for rules overriding
            return first.Points > second.Points ? first : second;
        }

        internal static DieRollResult Default()
        {
            return new DieRollResult(DiceCombination.None, 0);
        }
    }
}