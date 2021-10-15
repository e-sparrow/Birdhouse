using ESparrow.Utils.Generalization.Types.Enums;
using ESparrow.Utils.Generalization.Interpolation.Interfaces;
using ESparrow.Utils.Tools;

namespace ESparrow.Utils.Generalization.Interpolation.Adapters
{
    public abstract class ToInterpolatableAdapterBase<T> : IInteropolatable<T>
    {
        private readonly Reference<T> _reference;

        public T Value
        {
            get => _reference.Value;
            set => _reference.Value = value;
        }

        protected ToInterpolatableAdapterBase(Reference<T> reference)
        {
            _reference = reference;
        }

        public abstract void Interpolate(T from, T to, float progress);

        public abstract EGeneralizationType GeneralizationType
        {
            get;
        }
    }
}
