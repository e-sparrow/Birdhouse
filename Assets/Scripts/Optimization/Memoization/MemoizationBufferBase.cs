using System;
using System.Collections.Generic;
using ESparrow.Utils.Optimization.Memoization.Interfaces;
using ESparrow.Utils.Tools.DateAndTime.Expiration.Interfaces;

namespace ESparrow.Utils.Optimization.Memoization
{
    public abstract class MemoizationBufferBase<TKey, TValue> : IMemoizationBuffer<TKey, TValue>
    {
        private readonly Dictionary<TKey, IMemoizationElement<TValue>> _dictionary
            = new Dictionary<TKey, IMemoizationElement<TValue>>();

        protected abstract ITerm CreateTerm();

        public TValue GetOrCreate(TKey key, Func<TValue> create)
        {
            return GetOrCreate(key, create, CreateTerm());
        }

        public TValue GetOrCreate(TKey key, Func<TValue> create, ITerm term)
        {
            if (!_dictionary.ContainsKey(key))
            {
                _dictionary[key] = new MemoizationElement<TValue>(create.Invoke(), term);
            }
            
            return _dictionary[key].Value;
        }

        public void Check()
        {
            foreach (var item in _dictionary)
            {
                if (item.Value.Term.Check())
                {
                    _dictionary.Remove(item.Key);
                }
            }
        }
    }
}