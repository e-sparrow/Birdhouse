using ESparrow.Utils.Tools.Substitution.Enums;
using ESparrow.Utils.Tools.Substitution.Interfaces;

namespace ESparrow.Utils.Tools.Substitution.Methods
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