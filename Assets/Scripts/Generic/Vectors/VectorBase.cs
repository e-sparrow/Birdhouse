using System.Collections.Generic;
using ESparrow.Utils.Generic.Vectors.Interfaces;

namespace ESparrow.Utils.Generic.Vectors
{
    public abstract class VectorBase<T> : IVector<T>
    {
        protected VectorBase(List<T> list)
        {
            _list = list;
        }

        public T this[int dimension]
        {
            get => _list[dimension];
            set => _list[dimension] = value;
        }

        private readonly List<T> _list;

        public int Dimensions => _list.Count;
    }
}