using System.Collections.Generic;

namespace ESparrow.Utils.Tools.Substitution.Operators.Adapters
{
    public sealed class ListToSubstitutionOperatorAdapter<TElement> : SubstitutionOperatorBase<List<TElement>, TElement>
    {
        public ListToSubstitutionOperatorAdapter(List<TElement> enumerable) : base(enumerable)
        {
            
        }

        protected override void InsertAt(int index, TElement element, List<TElement> enumerable)
        {
            enumerable.Insert(index, element);
        }

        protected override void RemoveAt(int index, List<TElement> enumerable)
        {
            enumerable.RemoveAt(index);
        }
    }
}