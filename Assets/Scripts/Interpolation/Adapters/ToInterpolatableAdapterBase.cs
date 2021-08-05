using ESparrow.Utils.Tools;
using ESparrow.Utils.Interpolation.Interfaces;

namespace ESparrow.Utils.Interpolation.Adapters
{
    public abstract class ToInterpolatableAdapterBase<T> : IInteropolatable<T>
    {
        private Reference<T> _reference;

        public T Value
        {
            get => _reference.Value;
            set => _reference.Value = value;
        }

        public ToInterpolatableAdapterBase(Reference<T> reference)
        {
            _reference = reference;
        }

        public abstract void Interpolate(T from, T to, float t);
    }
}
