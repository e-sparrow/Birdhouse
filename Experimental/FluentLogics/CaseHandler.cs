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

        public SwitchSoHandler<T> So(Action action)
        {
            _root.Add(new SwitchConstruction<T>(_condition, action));
            return new SwitchSoHandler<T>(_root);
        }
    }
    
    public readonly struct CaseHandler<TIn, TOut>
    {
        public CaseHandler(SwitchRoot<TIn, TOut> root, Func<TIn, bool> condition)
        {
            _root = root;
            _condition = condition;
        }

        private readonly SwitchRoot<TIn, TOut> _root;
        private readonly Func<TIn, bool> _condition;
        

        public SwitchSoHandler<TIn, TOut> So(Func<TOut> func)
        {
            _root.Add(new SwitchConstruction<TIn, TOut>(_condition, func));
            return new SwitchSoHandler<TIn, TOut>(_root);
        }
    }
}