using ESparrow.Utils.Generalization.Summation.Interfaces;
using ESparrow.Utils.Tools.Streaks.Interfaces;

namespace ESparrow.Utils.Tools.Streaks
{
    public abstract class StreakBase<TSelf, TSummable> : IStreak<TSelf, TSummable> where TSummable : ISummable<TSelf>
    {
        protected StreakBase(ISummable<TSelf> summable, TSelf zero)
        {
            _summable = summable;
            
            _zero = zero;
            _summable.Value = _zero;
        }

        private ISummable<TSelf> _summable;
        
        private readonly TSelf _zero;

        public void Increase(TSelf amount)
        {
            _summable = _summable.Plus(amount);
        }

        public void CancelStreak()
        {
            _summable.Value = _zero;
        }

        public TSelf Current => _summable.Value;
    }
}