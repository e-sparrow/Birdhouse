using System;
using System.Collections.Generic;

namespace Birdhouse.Experimental.FluentLogics
{
    public sealed class SwitchRoot<T>
    {
        public SwitchRoot(T value) => _value = value;
        
        private readonly T _value;
        private readonly ICollection<SwitchConstruction<T>> _constructions = new List<SwitchConstruction<T>>();
 
        public void Execute(Action defaultAction)
        {
            foreach (var construction in _constructions)
                if (construction.Check(_value))
                    return;
            
            defaultAction.Invoke();
        }
 
        public SwitchSoHandler<T> So(Action action)
        {
            var construction = new SwitchConstruction<T>(_value);
            _constructions.Add(construction);
            var handler = new SwitchSoHandler<T>(this);
            return handler;
        }
    }

    public sealed class SwitchRoot<TIn, TOut>
    {
        
    }
}