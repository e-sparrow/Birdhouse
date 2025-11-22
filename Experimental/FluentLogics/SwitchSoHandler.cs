using System;

namespace Birdhouse.Experimental.FluentLogics
{
    public readonly struct SwitchSoHandler<T>
    {
        public SwitchSoHandler(SwitchRoot<T> root) => _root = root;

        private readonly SwitchRoot<T> _root;
        
        public CaseHandler<T> Case(Func<T, bool> condition) => new CaseHandler<T>(_root, condition);
        public void Default(Action action) => _root.Execute(action);
    }
    
    public readonly struct SwitchSoHandler<TIn, TOut>
    {
        public SwitchSoHandler(SwitchRoot<TIn, TOut> root) => _root = root;

        private readonly SwitchRoot<TIn, TOut> _root;

        public CaseHandler<TIn, TOut> Case(Func<TIn, bool> condition) => new CaseHandler<TIn, TOut>(_root, condition);
        public TOut Default(Func<TOut> func) => _root.Execute(func);
    }
}