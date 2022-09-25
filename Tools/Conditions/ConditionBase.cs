using Birdhouse.Tools.Conditions.Interfaces;

namespace Birdhouse.Tools.Conditions
{
    public abstract class ConditionBase<T> : ICondition<T>
    {
        protected ConditionBase(T origin, bool inverse)
        {
            _origin = origin;
            _inverse = inverse;
        }

        private readonly T _origin;
        private readonly bool _inverse;
        
        protected abstract bool Fit(T origin, T value);

        public bool Fit(T value)
        {
            var fit = Fit(_origin, value);
            return _inverse ? !fit : fit;
        }
    }
}