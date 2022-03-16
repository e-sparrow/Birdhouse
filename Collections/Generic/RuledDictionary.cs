using System;

namespace ESparrow.Utils.Collections.Generic
{
    public class RuledDictionary<TKey, TValue> : RuledDictionaryBase<TKey, TValue>
    {
        protected RuledDictionary(Func<TKey, TValue> rule) : base(rule)
        {
            
        }
    }
}
