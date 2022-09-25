using System.Collections.Generic;

namespace Birdhouse.Common.Collections.Generic
{
    public class MultiDictionary<TKey, TValue> : MultiDictionaryBase<TKey, TValue>
    {
        public MultiDictionary() : base(new Dictionary<TKey, List<TValue>>())
        {
            
        }

        public MultiDictionary(Dictionary<TKey, List<TValue>> dictionary) : base(dictionary)
        {

        }
    }
}
