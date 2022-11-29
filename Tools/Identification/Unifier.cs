using Birdhouse.Tools.Processors;

namespace Birdhouse.Tools.Identification
{
    public class Unifier<T> : UnifierBase<T>
    {
        public Unifier(Evaluator<T> unify)
        {
            _unify = unify;
        }

        private readonly Evaluator<T> _unify;

        public override T Unify(T value)
        {
            var result = _unify.Invoke(value);
            return result;
        }
    }
}