using System;
using System.Linq;
using ESparrow.Utils.Functionality;
using ESparrow.Utils.Helpers;
using ESparrow.Utils.Optimization.Memoization;
using ESparrow.Utils.Optimization.Memoization.Interfaces;
using ESparrow.Utils.Tools.DateAndTime.Expiration;
using ESparrow.Utils.Tools.DateAndTime.Expiration.Interfaces;

namespace ESparrow.Utils.Extensions
{
    public static class FunctionalityExtensions
    {
        public static Func<TArgument, TResult> AsPure<TArgument, TResult>(this Func<TArgument, TResult> func, IMemoizationBuffer<TArgument, TResult> buffer = default)
        {
            return Execute;

            TResult Execute(TArgument argument)
            {
                buffer ??= MemoizationHelper.CreateBuffer<TArgument, TResult>();
                var pureFunction = new PureFunction<TArgument, TResult>(buffer, func);

                return pureFunction.Execute(argument);
            }
        }   
        
        public static Func<TArgument, TResult> AsPure<TArgument, TResult>(this Func<TArgument, TResult> func, TimeSpan elementLifetime, IMemoizationBuffer<TArgument, TResult> buffer = default)
        {
            return Execute;

            TResult Execute(TArgument argument)
            {
                buffer ??= MemoizationHelper.CreateBuffer<TArgument, TResult>(elementLifetime);
                var pureFunction = new PureFunction<TArgument, TResult>(buffer, func);

                return pureFunction.Execute(argument);
            }
        }
        
        public static Func<TArgument, TResult> AsPure<TArgument, TResult>(this Func<TArgument, TResult> func, Func<ITermInfo> termInfoCreator, IMemoizationBuffer<TArgument, TResult> buffer = default)
        {
            return Execute;

            TResult Execute(TArgument argument)
            {
                buffer ??= MemoizationHelper.CreateBuffer<TArgument, TResult>(termInfoCreator);
                var pureFunction = new PureFunction<TArgument, TResult>(buffer, func);

                return pureFunction.Execute(argument);
            }
        }
    }
}
