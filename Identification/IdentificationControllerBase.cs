using ESparrow.Utils.Identification.Interfaces;

namespace ESparrow.Utils.Identification
{
    public abstract class IdentificationControllerBase<T> : IIdentificationController<T>
    {
        protected IdentificationControllerBase(IUnifier<T> unifier)
        {
            _unifier = unifier;
        }

        private readonly IUnifier<T> _unifier;

        protected abstract bool IsIdentical(T left, T right);
        
        public bool Identical(T left, T right)
        {
            var unifiedLeft = _unifier.Unify(left);
            var unifiedRight = _unifier.Unify(right);

            return IsIdentical(unifiedLeft, unifiedRight);
        }
    }
}