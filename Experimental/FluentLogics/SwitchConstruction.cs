using System;

namespace Birdhouse.Experimental.FluentLogics
{
    public readonly struct SwitchConstruction<T>
    {
        public SwitchConstruction(Func<T, bool> condition, Action action)
        {
            _condition = condition;
            _action = action;
        }
        
        private readonly Func<T, bool> _condition;
        private readonly Action _action;
        
        public bool Check(T value)
        {
            var result = _condition.Invoke(value);
            if (result) _action.Invoke();
            return result;
        }
    }
    
    public readonly struct SwitchConstruction<TIn, TOut>
    {
        public SwitchConstruction(Func<TIn, bool> condition, Func<TOut> func)
        {
            _condition = condition;
            _func = func;
        }
        
        private readonly Func<TIn, bool> _condition;
        private readonly Func<TOut> _func;
        
        public bool Check(TIn value, out TOut result)
        {
            result = default;
            
            var isSuccess = _condition.Invoke(value);
            if (isSuccess) result = _func.Invoke();
            return isSuccess;
        }
    }
}