using ESparrow.Utils.Generalization.Summation.Interfaces;

namespace ESparrow.Utils.Mechanics.Streaks.Interfaces
{
    public interface IStreak<TSelf, TSummable> where TSummable : ISummable<TSelf>
    {
        void Increase(TSelf amount);
        void CancelStreak();

        TSelf Current
        {
            get;
        }
    }
}
