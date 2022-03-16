using ESparrow.Utils.Generic.Pairs.Interfaces;

namespace ESparrow.Utils.Generic.Pairs
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
