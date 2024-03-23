using Birdhouse.Features.Aggregators;

namespace Birdhouse.Tools.Identification
{
    public class Unifier<T> 
        : UnifierBase<T>
    {
        public Unifier(Aggregation<T> unify)
        {
            _unify = unify;
        }

        private readonly Aggregation<T> _unify;

        public override T Unify(T value)
        {
            var result = _unify.Invoke(value);
            return result;
        }
    }
}