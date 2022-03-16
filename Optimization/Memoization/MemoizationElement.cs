using ESparrow.Utils.Optimization.Memoization.Interfaces;
using ESparrow.Utils.Tools.DateAndTime.Expiration.Interfaces;

namespace ESparrow.Utils.Optimization.Memoization
{
    public readonly struct MemoizationElement<T> : IMemoizationElement<T>
    {
        public MemoizationElement(T value, ITerm term)
        {
            Value = value;
            Term = term;
        }

        public T Value
        {
            get;
        }

        public ITerm Term
        {
            get;
        }
    }
}