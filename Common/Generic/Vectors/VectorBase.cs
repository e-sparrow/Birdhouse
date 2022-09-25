using System.Collections.Generic;
using Birdhouse.Common.Generic.Vectors.Interfaces;

namespace Birdhouse.Common.Generic.Vectors
{
    public abstract class VectorBase<T> : IVector<T>
    {
        protected VectorBase(IList<T> collection)
        {
            _collection = collection;
        }

        public T this[int dimension]
        {
            get => _collection[dimension];
            set => _collection[dimension] = value;
        }

        private readonly IList<T> _collection;

        public int Dimensions => _collection.Count;
    }
}