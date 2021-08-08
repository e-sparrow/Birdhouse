using System;

namespace ESparrow.Utils.Extensions
{
    public static class UniversalExtensions
    {
        public static T Use<T>(this T self, Action<T> action)
        {
            action.Invoke(self);
            return self;
        }

        public static TOut Get<TIn, TOut>(this TIn input, Func<TIn, TOut> func)
        {
            return func.Invoke(input);
        }

        public static T Modify<T>(this T input, Func<T, T> func)
        {
            return func.Invoke(input);
        }
    }
}
