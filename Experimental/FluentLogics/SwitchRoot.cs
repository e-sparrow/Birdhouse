using System;
using System.Collections.Generic;

namespace Birdhouse.Experimental.FluentLogics
{
    public sealed class SwitchRoot<T>
    {
        public SwitchRoot(T value) => _value = value;
        
        private readonly T _value;
        private readonly ICollection<SwitchConstruction<T>> _constructions = new List<SwitchConstruction<T>>();

        public SwitchRoot<T> Add(SwitchConstruction<T> construction)
        {
            _constructions.Add(construction);
            return this;
        }

        public void Execute(Action defaultAction)
        {
            foreach (var construction in _constructions)
                if (construction.Check(_value))
                    return;
            
            defaultAction.Invoke();
        }
 
        public CaseHandler<T> Case(Func<T, bool> condition) => new CaseHandler<T>(this, condition);
    }

    public sealed class SwitchRoot<TIn, TOut>
    {
        public SwitchRoot(TIn value) => _value = value;
        
        private readonly TIn _value;
        private readonly ICollection<SwitchConstruction<TIn, TOut>> _constructions 
            = new List<SwitchConstruction<TIn, TOut>>();
        
        public SwitchRoot<TIn, TOut> Add(SwitchConstruction<TIn, TOut> construction)
        {
            _constructions.Add(construction);
            return this;
        }
        
        public TOut Execute(Func<TOut> defaultFunc)
        {
            foreach (var construction in _constructions)
                if (construction.Check(_value, out var result))
                    return result;
            
            return defaultFunc.Invoke();
        }
 
        public CaseHandler<TIn, TOut> Case(Func<TIn, bool> condition) => new CaseHandler<TIn, TOut>(this, condition);
    }
}