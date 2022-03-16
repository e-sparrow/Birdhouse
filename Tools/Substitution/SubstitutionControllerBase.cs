using ESparrow.Utils.Tools.Substitution.Interfaces;
using ESparrow.Utils.Tools.Substitution.Enums;

namespace ESparrow.Utils.Tools.Substitution
{
    public abstract class SubstitutionControllerBase<TElement> : ISubstitutionController<TElement>
    {
        protected SubstitutionControllerBase(ISubstitutionMethod<TElement> substitutionMethod)
        {
            _substitutionMethod = substitutionMethod;
        }

        private readonly ISubstitutionMethod<TElement> _substitutionMethod;

        protected abstract void Add(TElement element, ISubstitutionMethod<TElement> method);

        public void Add(TElement element)
        {
            Add(element, _substitutionMethod);
        }
    }
}