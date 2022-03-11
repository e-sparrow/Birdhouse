using System;
using System.Collections.Generic;
using ESparrow.Utils.Optimization.Memoization.Interfaces;

namespace ESparrow.Utils.Optimization.Memoization
{
    public abstract class MemoizationBufferBase<TKey, TValue> : IMemoizationBuffer<TKey, TValue>
    {
        protected MemoizationBufferBase()
        {
            
        }

        private readonly Dictionary<TKey, TValue> _dictionary = new Dictionary<TKey, TValue>();

        public TValue GetOrCreate(TKey key, Func<TValue> create)
        {
            if (!_dictionary.ContainsKey(key))
            {
                _dictionary[key] = create.Invoke();
            }
            
            return _dictionary[key];
        }
    }
}