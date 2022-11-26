using System.Collections.Generic;

namespace Birdhouse.Tools.Substitution.Operators.Adapters
{
    public sealed class ListToSubstitutionOperatorAdapter<T> : SubstitutionOperatorBase<IList<T>, T>
    {
        public ListToSubstitutionOperatorAdapter(IList<T> enumerable) : base(enumerable)
        {
            
        }

        protected override void InsertAt(int index, T element, IList<T> enumerable)
        {
            enumerable.Insert(index, element);
        }

        protected override bool RemoveAt(int index, IList<T> enumerable)
        {
            var result = enumerable.Count > index;
            if (result)
            {
                enumerable.RemoveAt(index);    
            }
            
            return result;
        }
    }
}