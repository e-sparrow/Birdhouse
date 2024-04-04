using System;

namespace Birdhouse.Experimental.FluentLogics
{
    public readonly struct ConditionalConstruction
    {
        public ConditionalConstruction(Func<bool> func, Action action)
        {
            _func = func;
            _action = action;
        }
        
        private readonly Func<bool> _func;
        private readonly Action _action;
        
        public bool Check()
        {
            var result = _func.Invoke();
            if (result)
            {
                _action.Invoke();
            }

            return result;
        }
    }
    
    public readonly struct ConditionConstruction<T>
    {
        public ConditionConstruction(Func<bool> condition, Func<T> func)
        {
            _condition = condition;
            _func = func;
        }

        private readonly Func<bool> _condition;
        private readonly Func<T> _func;

        public bool Check(out T value)
        {
            value = default;
            
            var result = _condition.Invoke();
            if (result)
            {
                value = _func.Invoke();
            }

            return result;
        }
    }
}