using System.Collections;
using System.Collections.Generic;
using Birdhouse.Common.Collections.Generic.Interfaces;
using Birdhouse.Common.Generic.Vectors.Interfaces;

namespace Birdhouse.Common.Collections.Generic
{
    public abstract class MatrixBase<TValue, TIndexer> : IMatrix<TValue, TIndexer>
    {
        protected MatrixBase(IDictionary<IVector<TIndexer>, TValue> dictionary)
        {
            _dictionary = dictionary;
        }

        private readonly IDictionary<IVector<TIndexer>, TValue> _dictionary;

        public TValue this[IVector<TIndexer> key]
        {
            get => _dictionary[key];
            set => _dictionary[key] = value;
        }
        
        public IEnumerator<KeyValuePair<IVector<TIndexer>, TValue>> GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(KeyValuePair<IVector<TIndexer>, TValue> item)
        {
            _dictionary.Add(item);
        }

        public void Clear()
        {
            _dictionary.Clear();
        }

        public bool Contains(KeyValuePair<IVector<TIndexer>, TValue> item)
        {
            return _dictionary.Contains(item);
        }

        public void CopyTo(KeyValuePair<IVector<TIndexer>, TValue>[] array, int arrayIndex)
        {
            _dictionary.CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<IVector<TIndexer>, TValue> item)
        {
            return _dictionary.Remove(item);
        }

        public void Add(IVector<TIndexer> key, TValue value)
        {
            _dictionary.Add(key, value);
        }

        public bool ContainsKey(IVector<TIndexer> key)
        {
            return _dictionary.ContainsKey(key);
        }

        public bool Remove(IVector<TIndexer> key)
        {
            return _dictionary.Remove(key);
        }

        public bool TryGetValue(IVector<TIndexer> key, out TValue value)
        {
            return _dictionary.TryGetValue(key, out value);
        }

        public ICollection<IVector<TIndexer>> Keys => _dictionary.Keys;
        public ICollection<TValue> Values => _dictionary.Values;

        public int Count => _dictionary.Count;
        public bool IsReadOnly => _dictionary.IsReadOnly;
    }
}
