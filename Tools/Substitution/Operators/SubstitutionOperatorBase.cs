using System.Collections.Generic;
using System.Linq;
using Birdhouse.Tools.Substitution.Interfaces;

namespace Birdhouse.Tools.Substitution.Operators
{
    public abstract class SubstitutionOperatorBase<TEnumerable, TElement> : ISubstitutionOperator<TElement>
        where TEnumerable : IEnumerable<TElement>
    {
        protected SubstitutionOperatorBase(TEnumerable enumerable)
        {
            _enumerable = enumerable;
        }

        private readonly TEnumerable _enumerable;

        protected abstract void InsertAt(int index, TElement element, TEnumerable enumerable);
        protected abstract bool RemoveAt(int index, TEnumerable enumerable);

        public void InsertAt(int index, TElement element)
        {
            InsertAt(index, element, _enumerable);
        }

        public bool RemoveAt(int index)
        {
            var result = RemoveAt(index, _enumerable);
            return result;
        }

        public int Count => _enumerable.Count();
    }
}