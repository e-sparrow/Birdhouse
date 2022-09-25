using Birdhouse.Tools.Identification.Interfaces;

namespace Birdhouse.Tools.Identification
{
    public abstract class IdentificationProviderBase<T> : IIdentificationProvider<T>
    {
        protected IdentificationProviderBase(IUnifier<T> unifier)
        {
            _unifier = unifier;
        }

        private readonly IUnifier<T> _unifier;

        protected abstract bool IsIdentical(T left, T right);
        
        public bool CheckIdentity(T left, T right)
        {
            var unifiedLeft = _unifier.Unify(left);
            var unifiedRight = _unifier.Unify(right);

            return IsIdentical(unifiedLeft, unifiedRight);
        }
    }
}