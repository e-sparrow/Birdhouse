using Birdhouse.Common.Generic.Pairs.Interfaces;

namespace Birdhouse.Common.Generic.Pairs
{
    public abstract class PairBase<TKey, TValue> : IPair<TKey, TValue>
    {
        protected PairBase(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        public TKey Key
        {
            get;
        }

        public TValue Value
        {
            get;
        }
    }
}
