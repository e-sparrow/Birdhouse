using System;

namespace Birdhouse.Common.Delegates
{
    public static class ConditionalFuncExtensions
    {
        public static TOut GetOrThrow<TIn, TOut>
            (this ConditionalFunc<TIn, TOut> self, TIn parameter, Func<Exception> onFail)
        {
            var isSuccess = self.Invoke(parameter, out var result);
            if (!isSuccess)
            {
                var exception = onFail.Invoke();
                throw exception;
            }

            return result;
        }
        
        public static TOut GetOrThrow<TIn1, TIn2, TOut>
            (this ConditionalFunc<TIn1, TIn2, TOut> self, TIn1 parameter1, TIn2 parameter2, Func<Exception> onFail)
        {
            var isSuccess = self.Invoke(parameter1, parameter2, out var result);
            if (!isSuccess)
            {
                var exception = onFail.Invoke();
                throw exception;
            }

            return result;
        }
        
        public static TOut GetOrThrow<TIn1, TIn2, TIn3, TOut>
        (
            this ConditionalFunc<TIn1, TIn2, TIn3, TOut> self,
            TIn1 parameter1, 
            TIn2 parameter2, 
            TIn3 parameter3,
            Func<Exception> onFail
        )
        {
            var isSuccess = self.Invoke(parameter1, parameter2, parameter3, out var result);
            if (!isSuccess)
            {
                var exception = onFail.Invoke();
                throw exception;
            }

            return result;
        }
    }
}