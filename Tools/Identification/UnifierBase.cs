using Birdhouse.Tools.Identification.Interfaces;

namespace Birdhouse.Tools.Identification
{
    public abstract class UnifierBase<T> : IUnifier<T>
    {
        public abstract T Unify(T value);
    }
}