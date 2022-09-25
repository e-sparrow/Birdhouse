using Birdhouse.Tools.Substitution.Enums;
using Birdhouse.Tools.Substitution.Interfaces;

namespace Birdhouse.Tools.Substitution.Methods
{
    public class ForgetSubstitutionMethod<TElement> : SubstitutionMethodBase<TElement>
    {
        public ForgetSubstitutionMethod(ISubstitutionOperator<TElement> substitutionOperator) : base(substitutionOperator)
        {
            
        }

        protected override void Replace(TElement element, ISubstitutionOperator<TElement> substitutionOperator)
        {
            substitutionOperator.RemoveAt(0);
            substitutionOperator.InsertAt(substitutionOperator.Count, element);
        }

        public override ESubstitutionType Type => ESubstitutionType.Forget;
    }
}