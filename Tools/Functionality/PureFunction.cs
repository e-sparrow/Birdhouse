using System;
using Birdhouse.Tools.Optimization.Memoization.Interfaces;

namespace Birdhouse.Tools.Functionality
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

    public class PureFunction : PureFunction<object[], object>
    {
        public PureFunction(IMemoizationBuffer<object[], object> buffer, Func<object[], object> func) : base(buffer, func)
        {
            
        }
    }
}