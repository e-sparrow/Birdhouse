using System;
using ESparrow.Utils.Optimization.Memoization.Interfaces;

namespace ESparrow.Utils.Functionality
{
    public class PureFunction<TArgument, TResult> : PureFunctionBase<TArgument, TResult>
    {
        public PureFunction(IMemoizationBuffer<TArgument, TResult> buffer, Func<TArgument, TResult> func) : base(buffer, func)
        {
            
        }
    }

    public class PureFunction<TResult> : PureFunction<object[], TResult>
    {
        public PureFunction(IMemoizationBuffer<object[], TResult> buffer, Func<object[], TResult> func) : base(buffer, func)
        {
            
        }
    }
}