using ESparrow.Utils.Tools.Eases.Interfaces;

namespace ESparrow.Utils.Tools.Eases
{
    public abstract class StartFinishEaseApplierBase<T> : IEaseApplier<T>
    {
        protected StartFinishEaseApplierBase(IStartFinishEaseApplierParams<T> applierParams) : this(applierParams.Start, applierParams.Finish, applierParams.Ease)
        {
            
        }
        
        protected StartFinishEaseApplierBase(T start, T finish, IEase ease)
        {
            _start = start;
            _finish = finish;
            
            _ease = ease;
        }

        private readonly T _start;
        private readonly T _finish;
        
        private readonly IEase _ease;

        protected abstract T Lerp(T start, T finish, float progress);

        public T Evaluate(float progress)
        {
            return Lerp(_start, _finish, _ease.Evaluate(progress));
        }
    }
}
