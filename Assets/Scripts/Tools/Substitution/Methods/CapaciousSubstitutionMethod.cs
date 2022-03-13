using ESparrow.Utils.Tools.Substitution.Interfaces;

namespace ESparrow.Utils.Tools.Substitution.Methods
{
    public class CapaciousSubstitutionMethod<TElement> : CapaciousSubstitutionMethodBase<TElement>
    {
        public CapaciousSubstitutionMethod(int capacity, ISubstitutionMethod<TElement> method, ISubstitutionOperator<TElement> substitutionOperator) : base(capacity, method, substitutionOperator)
        {
            
        }

        protected override void ReduceTo(int count, ISubstitutionOperator<TElement> substitutionOperator)
        {
            for (int index = substitutionOperator.Count; index > count; index--)
            {
                substitutionOperator.RemoveAt(index - 1);
            }
        }
    }
}