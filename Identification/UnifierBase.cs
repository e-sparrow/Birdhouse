using ESparrow.Utils.Identification.Interfaces;

namespace ESparrow.Utils.Identification
{
    public abstract class UnifierBase<T> : IUnifier<T>
    {
        public abstract T Unify(T value);
    }
}