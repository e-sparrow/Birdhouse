using ESparrow.Utils.Tools.Substitution.Enums;
using ESparrow.Utils.Tools.Substitution.Interfaces;

namespace ESparrow.Utils.Tools.Substitution.Methods
{
    public class IgnoreSubstitutionMethod<TElement> : SubstitutionMethodBase<TElement>
    {
        public IgnoreSubstitutionMethod(ISubstitutionOperator<TElement> substitutionOperator) : base(substitutionOperator)
        {
        }

        protected override void Replace(TElement element, ISubstitutionOperator<TElement> substitutionOperator)
        {
            
        }

        public override ESubstitutionType Type => ESubstitutionType.Ignore;
    }
}