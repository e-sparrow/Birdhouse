using System;

namespace Birdhouse.Experimental.FluentLogics
{
    public readonly struct SwitchSoHandler<T>
    {
        public SwitchSoHandler(SwitchRoot<T> root) => _root = root;

        private readonly SwitchRoot<T> _root;
        
        public CaseHandler<T> Case(Func<bool> func) => new CaseHandler<T>(_root, func);
        public DefaultHandler<T> Default() => new DefaultHandler<T>(_root);
    }
}