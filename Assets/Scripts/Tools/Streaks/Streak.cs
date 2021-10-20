using ESparrow.Utils.Generalization.Summation.Interfaces;

namespace ESparrow.Utils.Tools.Streaks
{
    public class Streak<TSelf, TSummable> : StreakBase<TSelf, TSummable> where TSummable : ISummable<TSelf>
    {
        public Streak(ISummable<TSelf> summable, TSelf zero) : base(summable, zero)
        {
            
        }
    }
}