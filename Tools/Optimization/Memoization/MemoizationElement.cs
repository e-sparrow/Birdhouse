using Birdhouse.Tools.Optimization.Memoization.Interfaces;
using Birdhouse.Tools.Tense.Expiration.Interfaces;

namespace Birdhouse.Tools.Optimization.Memoization
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