using System.Collections;
using System.Collections.Generic;
using ESparrow.Utils.Collections.Generic.Interfaces;
using ESparrow.Utils.Generic.Vectors.Interfaces;

namespace ESparrow.Utils.Collections.Generic
{
//TODO     
    public class MatrixBase<TValue, TIndexer> : IMatrix<TValue, TIndexer>
    {
        public TValue this[IVector<TIndexer> key]
        {
            get => throw new System.NotImplementedException();
            set => throw new System.NotImplementedException();
        }
        
        public IEnumerator<KeyValuePair<IVector<TIndexer>, TValue>> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(KeyValuePair<IVector<TIndexer>, TValue> item)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(KeyValuePair<IVector<TIndexer>, TValue> item)
        {
            throw new System.NotImplementedException();
        }

        public void CopyTo(KeyValuePair<IVector<TIndexer>, TValue>[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(KeyValuePair<IVector<TIndexer>, TValue> item)
        {
            throw new System.NotImplementedException();
        }

        public void Add(IVector<TIndexer> key, TValue value)
        {
            throw new System.NotImplementedException();
        }

        public bool ContainsKey(IVector<TIndexer> key)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(IVector<TIndexer> key)
        {
            throw new System.NotImplementedException();
        }

        public bool TryGetValue(IVector<TIndexer> key, out TValue value)
        {
            throw new System.NotImplementedException();
        }
        
        public int Count { get; }
        public bool IsReadOnly { get; }

        public ICollection<IVector<TIndexer>> Keys { get; }
        public ICollection<TValue> Values { get; }
    }
}
