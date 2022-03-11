using System;
using ESparrow.Utils.Collections.Generic.Interfaces;

namespace ESparrow.Utils.Collections.Generic
{
    public class RuledDictionaryBase<TKey, TValue> : IRuledDictionary<TKey, TValue>
    {
        protected RuledDictionaryBase(Func<TKey, TValue> rule)
        {
            _rule = rule;
        }

        public TValue this[TKey key] => GetValue(key);

        private readonly Func<TKey, TValue> _rule;
        
        public TValue GetValue(TKey key)
        {
            return _rule.Invoke(key);
        }

        public static explicit operator RuledDictionaryBase<TKey, TValue>(Func<TKey, TValue> rule)
        {
            return new RuledDictionaryBase<TKey, TValue>(rule);
        }

        public static implicit operator Func<TKey, TValue>(RuledDictionaryBase<TKey, TValue> dictionary)
        {
            return dictionary._rule;
        }
    }
}
