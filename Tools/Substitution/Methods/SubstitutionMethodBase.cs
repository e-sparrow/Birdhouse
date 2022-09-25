using Birdhouse.Tools.Substitution.Enums;
using Birdhouse.Tools.Substitution.Interfaces;

namespace Birdhouse.Tools.Substitution.Methods
{
    public abstract class SubstitutionMethodBase<TElement> : ISubstitutionMethod<TElement>
    {
        protected SubstitutionMethodBase(ISubstitutionOperator<TElement> substitutionOperator)
        {
            _substitutionOperator = substitutionOperator;
        }

        private readonly ISubstitutionOperator<TElement> _substitutionOperator;

        protected abstract void Replace(TElement element, ISubstitutionOperator<TElement> substitutionOperator);

        public void Apply(TElement element, bool replace)
        {
            if (replace)
            {
                Replace(element, _substitutionOperator);
            }
            else
            {
                _substitutionOperator.InsertAt(_substitutionOperator.Count, element);
            }
        }

        public abstract ESubstitutionType Type
        {
            get;
        }
    }
}