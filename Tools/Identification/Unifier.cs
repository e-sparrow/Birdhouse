using Birdhouse.Features.Processors;

namespace Birdhouse.Tools.Identification
{
    public class Unifier<T> : UnifierBase<T>
    {
        public Unifier(Aggregator<T> unify)
        {
            _unify = unify;
        }

        private readonly Aggregator<T> _unify;

        public override T Unify(T value)
        {
            var result = _unify.Invoke(value);
            return result;
        }
    }
}