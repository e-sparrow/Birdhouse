using System;
using ESparrow.Utils.Functionality;
using ESparrow.Utils.Helpers;
using ESparrow.Utils.Optimization.Memoization;
using ESparrow.Utils.Tools.DateAndTime.Expiration;
using ESparrow.Utils.Tools.DateAndTime.Expiration.Interfaces;

namespace ESparrow.Utils.Extensions
{
    public static class MemoizationExtensions
    {
        public static Func<TArgument, TResult> AsPure<TArgument, TResult>(this Func<TArgument, TResult> func)
        {
            return Execute;

            TResult Execute(TArgument argument)
            {
                var buffer = MemoizationHelper.CreateBuffer<TArgument, TResult>();
                var pureFunction = new PureFunction<TArgument, TResult>(buffer, func);

                return pureFunction.Execute(argument);
            }
        }
        
        public static Func<TArgument, TResult> AsPure<TArgument, TResult>(this Func<TArgument, TResult> func, TimeSpan elementLifetime)
        {
            return Execute;

            TResult Execute(TArgument argument)
            {
                var buffer = MemoizationHelper.CreateBuffer<TArgument, TResult>(elementLifetime);
                var pureFunction = new PureFunction<TArgument, TResult>(buffer, func);

                return pureFunction.Execute(argument);
            }
        }
        
        public static Func<TArgument, TResult> AsPure<TArgument, TResult>(this Func<TArgument, TResult> func, Func<ITermInfo> termInfoCreator)
        {
            return Execute;

            TResult Execute(TArgument argument)
            {
                var buffer = MemoizationHelper.CreateBuffer<TArgument, TResult>(termInfoCreator);
                var pureFunction = new PureFunction<TArgument, TResult>(buffer, func);

                return pureFunction.Execute(argument);
            }
        }
    }
}
