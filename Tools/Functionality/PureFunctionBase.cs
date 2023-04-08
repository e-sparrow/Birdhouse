using System;
using Birdhouse.Tools.Functionality.Interfaces;
using Birdhouse.Tools.Optimization.Memoization.Interfaces;

namespace Birdhouse.Tools.Functionality
{
    public abstract class PureFunctionBase<TArgument, TResult> : IPureFunction<TArgument, TResult>
    {
        protected PureFunctionBase(IMemoizationBuffer<TArgument, TResult> buffer, Func<TArgument, TResult> func)
        {
            _func = GetOrCreate;

            TResult GetOrCreate(TArgument argument)
            {
                var value = buffer.GetOrCreate(argument, Create);
                return value;

                TResult Create()
                {
                    var result = func.Invoke(argument);
                    return result;
                }
            }
        }

        private readonly Func<TArgument, TResult> _func;

        public TResult Execute(TArgument argument)
        {
            var result = _func.Invoke(argument);
            return result;
        }
    }
}