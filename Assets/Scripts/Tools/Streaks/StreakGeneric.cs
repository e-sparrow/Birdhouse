using ESparrow.Utils.Generalization.Summation.Interfaces;

namespace ESparrow.Utils.Tools.Streaks
{
    public class StreakGeneric<TSelf, TSummable> : StreakBase<TSelf, TSummable> where TSummable : ISummable<TSelf>
    {
        public StreakGeneric(ISummable<TSelf> summable, TSelf zero) : base(summable, zero)
        {
            
        }
    }
}