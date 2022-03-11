using ESparrow.Utils.Tools.Easing.Interfaces;

namespace ESparrow.Utils.Tools.Easing
{
    public abstract class EaseBase : IEase
    {
        protected EaseBase(Easing<float> easing)
        {
            _easing = easing;
        }

        private readonly Easing<float> _easing;
        
        protected abstract float Evaluate(Easing<float> easing, float progress);

        public float Evaluate(float progress)
        {
            return Evaluate(_easing, progress);
        }
    }
}
