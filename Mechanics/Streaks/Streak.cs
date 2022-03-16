using ESparrow.Utils.Generalization.Summation.Interfaces;

namespace ESparrow.Utils.Mechanics.Streaks
{
    public class Streak<TSelf, TSummable> : StreakBase<TSelf, TSummable> where TSummable : ISummable<TSelf>
    {
        public Streak(TSummable summable, TSelf zero) : base(summable, zero)
        {
            
        }
    }
}