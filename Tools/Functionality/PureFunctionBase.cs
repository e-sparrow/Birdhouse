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
                return buffer.GetOrCreate(argument, Create);

                TResult Create()
                {
                    return func.Invoke(argument);
                }
            }
        }

        private readonly Func<TArgument, TResult> _func;

        public TResult Execute(TArgument argument)
        {
            return _func.Invoke(argument);
        }
    }
}