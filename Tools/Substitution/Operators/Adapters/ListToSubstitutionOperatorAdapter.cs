using System.Collections.Generic;

namespace ESparrow.Utils.Tools.Substitution.Operators.Adapters
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

        protected override void RemoveAt(int index, IList<T> enumerable)
        {
            enumerable.RemoveAt(index);
        }
    }
}