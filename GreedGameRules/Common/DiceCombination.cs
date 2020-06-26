namespace GreedGameRules
{
    public enum DiceCombination
    {
        [Display("Nothing")]
        None = -1,
        [Display("Full house")]
        FullHouse = 100,
        [Display("Low straight")]
        StraightLow = 96,
        [Display("High straight")]
        StraightHigh = 97,
        [Display("Five of a kind")]
        FiveOfAKind = 90,
        [Display("Four of a kind")]
        FourOfAKind = 85,
        [Display("Three of a kind")]
        ThreeOfAKind = 80,
        [Display("A pair")]
        Pair = 50,
        [Display("Two pairs")]
        TwoPair = 55,
    }
}
