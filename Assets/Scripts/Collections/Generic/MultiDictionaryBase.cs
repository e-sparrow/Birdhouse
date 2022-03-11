using System.Collections;
using System.Collections.Generic;
using ESparrow.Utils.Collections.Generic.Interfaces;

namespace ESparrow.Utils.Collections.Generic
{
    public abstract class MultiDictionaryBase<TKey, TValue> : IMultiDictionary<TKey, TValue>
    {
        protected MultiDictionaryBase(Dictionary<TKey, List<TValue>> dictionary)
        {
            _dictionaryInternal = dictionary;
        }
        
        public IReadOnlyCollection<TValue> this[TKey key] => _dictionaryInternal[key];

        private readonly Dictionary<TKey, List<TValue>> _dictionaryInternal;

        public void Add(TKey key, TValue value)
        {
            if (!_dictionaryInternal.ContainsKey(key))
            {
                _dictionaryInternal[key] = new List<TValue>();
            }
            
            _dictionaryInternal[key].Add(value);
        }

        public bool Remove(TKey key, TValue value)
        {
            var containsKey = _dictionaryInternal.ContainsKey(key);
            if (!containsKey) return false;

            var containsValue = _dictionaryInternal[key].Contains(value);
            if (!containsValue) return false;

            return _dictionaryInternal[key].Remove(value);
        }

        public IEnumerator<KeyValuePair<TKey, IReadOnlyCollection<TValue>>> GetEnumerator()
        {
            return new MultiDictionaryEnumerator(_dictionaryInternal.GetEnumerator());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool ContainsKey(TKey key)
        {
            return _dictionaryInternal.ContainsKey(key);
        }

        public bool TryGetValue(TKey key, out IReadOnlyCollection<TValue> value)
        {
            var result = _dictionaryInternal.TryGetValue(key, out var list);
            value = list;

            return result;
        }


        public int Count => _dictionaryInternal.Count;
        
        public IEnumerable<TKey> Keys => _dictionaryInternal.Keys;
        public IEnumerable<IReadOnlyCollection<TValue>> Values => _dictionaryInternal.Values;

        private class MultiDictionaryEnumerator : IEnumerator<KeyValuePair<TKey, IReadOnlyCollection<TValue>>>
        {
            public MultiDictionaryEnumerator(Dictionary<TKey, List<TValue>> dictionary)
            {
                _enumeratorInternal = dictionary.GetEnumerator();
            }

            public MultiDictionaryEnumerator(IEnumerator<KeyValuePair<TKey, List<TValue>>> enumerator)
            {
                _enumeratorInternal = enumerator;
            }

            private readonly IEnumerator<KeyValuePair<TKey, List<TValue>>> _enumeratorInternal;
            
            public KeyValuePair<TKey, IReadOnlyCollection<TValue>> Current
            {
                get
                {
                    var current =  _enumeratorInternal.Current;
                    return new KeyValuePair<TKey, IReadOnlyCollection<TValue>>(current.Key, current.Value);
                }
            }
            
            object IEnumerator.Current => Current;
            
            public bool MoveNext()
            {
                return _enumeratorInternal.MoveNext();
            }

            public void Reset()
            {
                _enumeratorInternal.Reset();
            }

            public void Dispose()
            {
                _enumeratorInternal.Dispose();
            }
        }
    }
}
