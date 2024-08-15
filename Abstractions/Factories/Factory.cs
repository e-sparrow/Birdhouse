using System;

namespace Birdhouse.Abstractions.Factories
{
    public sealed class Factory
        : IFactory
    {
        public Factory(Func<object[], object> func)
        {
            _func = func;
        }

        private readonly Func<object[], object> _func;
        
        public object Create(object[] input)
        {
            var result = _func.Invoke(input);
            return result;
        }
    }
    
    public sealed class Factory<TIn, TOut>
        : IFactory<TIn, TOut>
    {
        public Factory(Func<TIn, TOut> func)
        {
            _func = func;
        }

        private readonly Func<TIn, TOut> _func;

        public TOut Create(TIn input)
        {
            var result = _func.Invoke(input);
            return result;
        }
    }
    
    public sealed class Factory<TIn1, TIn2, TOut>
        : IFactory<TIn1, TIn2, TOut>
    {
        public Factory(Func<TIn1, TIn2, TOut> func)
        {
            _func = func;
        }

        private readonly Func<TIn1, TIn2, TOut> _func;
        
        public TOut Create(TIn1 input1, TIn2 input2)
        {
            var result = _func.Invoke(input1, input2);
            return result;
        }
    }
    
    public sealed class Factory<TIn1, TIn2, TIn3, TOut>
        : IFactory<TIn1, TIn2, TIn3, TOut>
    {
        public Factory(Func<TIn1, TIn2, TIn3, TOut> func)
        {
            _func = func;
        }

        private readonly Func<TIn1, TIn2, TIn3, TOut> _func;
        
        public TOut Create(TIn1 input1, TIn2 input2, TIn3 input3)
        {
            var result = _func.Invoke(input1, input2, input3);
            return result;
        }
    }
}