using System;

namespace Birdhouse.Tools.Identification
{
    public class Unifier<T> : UnifierBase<T>
    {
        public Unifier(Func<T, T> unify)
        {
            _unify = unify;
        }

        private readonly Func<T, T> _unify;

        public override T Unify(T value)
        {
            return _unify.Invoke(value);
        }
    }
}