using Birdhouse.Tools.Generalization.Summation.Interfaces;

namespace Birdhouse.Mechanics.Streaks
{
    public class Streak<TSelf, TSummable> : StreakBase<TSelf, TSummable> where TSummable : ISummable<TSelf>
    {
        public Streak(TSummable summable, TSelf zero) : base(summable, zero)
        {
            
        }
    }
}