using ESparrow.Utils.Tools.Eases.Interfaces;

namespace ESparrow.Utils.Tools.Eases
{
    public abstract class EaseApplierBase<T> : IEaseApplier<T>
    {
        protected EaseApplierBase(Easing<T> easing)
        {
            _easing = easing;
        }

        private readonly Easing<T> _easing;

        public T Evaluate(float progress)
        {
            return _easing.Invoke(progress);
        }
    }
}
