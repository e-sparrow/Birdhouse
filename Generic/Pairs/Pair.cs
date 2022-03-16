using System.Collections.Generic;

namespace ESparrow.Utils.Generic.Pairs
{
    public class Pair<TKey, TValue> : PairBase<TKey, TValue>
    {
        public Pair(TKey key, TValue value) : base(key, value)
        {

        }

        public Pair(KeyValuePair<TKey, TValue> keyValuePair) : base(keyValuePair.Key, keyValuePair.Value)
        {
            
        }
    }
}