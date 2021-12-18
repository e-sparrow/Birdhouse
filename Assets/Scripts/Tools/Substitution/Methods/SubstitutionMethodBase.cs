using ESparrow.Utils.Tools.Substitution.Enums;
using ESparrow.Utils.Tools.Substitution.Interfaces;

namespace ESparrow.Utils.Tools.Substitution.Methods
{
    public abstract class SubstitutionMethodBase<TElement> : ISubstitutionMethod<TElement>
    {
        protected SubstitutionMethodBase(ISubstitutionOperator<TElement> substitutionOperator)
        {
            _substitutionOperator = substitutionOperator;
        }

        private readonly ISubstitutionOperator<TElement> _substitutionOperator;

        protected abstract void Replace(TElement element, ISubstitutionOperator<TElement> substitutionOperator);
        
        public void Apply(TElement element)
        {
            Replace(element, _substitutionOperator);
        }

        public abstract ESubstitutionType Type
        {
            get;
        }
    }
}