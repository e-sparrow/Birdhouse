using Birdhouse.Tools.Substitution.Enums;
using Birdhouse.Tools.Substitution.Interfaces;

namespace Birdhouse.Tools.Substitution.Methods
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