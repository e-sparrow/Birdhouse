using ESparrow.Utils.Tools.Substitution.Interfaces;
using ESparrow.Utils.Tools.Substitution.Enums;

namespace ESparrow.Utils.Tools.Substitution
{
    public abstract class SubstitutionController<TElement> : ISubstitutionController<TElement>
    {
        protected SubstitutionController(ISubstitutionMethod<TElement> substitutionMethod)
        {
            _substitutionMethod = substitutionMethod;
        }

        private readonly ISubstitutionMethod<TElement> _substitutionMethod;

        public void Substitute(TElement element)
        {
            _substitutionMethod.Apply(element);
        }
    }
}