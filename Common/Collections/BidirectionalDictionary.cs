using System.Collections;
using System.Collections.Generic;
using Birdhouse.Common.Collections.Abstractions;

namespace Birdhouse.Common.Collections
{
    // TODO:
    public sealed class BidirectionalDictionary<TKey, TValue>
        : IBidirectionalDictionary<TKey, TValue>
    {
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public TKey this[TValue value] => throw new System.NotImplementedException();

        public TValue this[TKey key] => throw new System.NotImplementedException();

        public bool ContainsKey(TKey key)
        {
            throw new System.NotImplementedException();
        }

        public bool ContainsValue(TValue value)
        {
            throw new System.NotImplementedException();
        }
    }
}