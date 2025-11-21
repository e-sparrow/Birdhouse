using System;

namespace Birdhouse.Experimental.FluentLogics
{
    public readonly struct SwitchConstruction<T>
    {
        public SwitchConstruction(Func<T, bool> condition, T value) => _condition = condition;

        private readonly Func<T, bool> _condition;
        public bool Check(T value) => _condition.Invoke(value);
    }
}