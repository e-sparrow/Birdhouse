using System;

namespace Birdhouse.Experimental.FluentLogics
{
    public readonly struct CaseHandler<T>
    {
        public CaseHandler(SwitchRoot<T> root, Func<T, bool> condition)
        {
            _root = root;
            _condition = condition;
        }

        private readonly SwitchRoot<T> _root;
        private readonly Func<T, bool> _condition;
    }
}