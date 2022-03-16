using ESparrow.Utils.Tools.Substitution.Enums;
using ESparrow.Utils.Tools.Substitution.Interfaces;

namespace ESparrow.Utils.Tools.Substitution.Methods
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

        public override ESubstitutionType Type => ESubstitutionType.Update;
    }
}