using Birdhouse.Tools.Substitution.Interfaces;

namespace Birdhouse.Tools.Substitution.Methods
{
    public class UpdateSubstitutionMethod<TElement> : SubstitutionMethodBase<TElement>
    {
        public UpdateSubstitutionMethod(ISubstitutionOperator<TElement> substitutionOperator) : base(substitutionOperator)
        {
            
        }

        protected override void Replace(TElement element, ISubstitutionOperator<TElement> substitutionOperator)
        {
            substitutionOperator.RemoveAt(substitutionOperator.Count - 1);
            substitutionOperator.InsertAt(substitutionOperator.Count, element);
        }
    }
}