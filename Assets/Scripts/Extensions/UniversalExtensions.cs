using System;

namespace ESparrow.Utils.Extensions
{
    public static class UniversalExtensions
    {
        public static TOut Get<TIn, TOut>(this TIn input, Func<TIn, TOut> func)
        {
            return func.Invoke(input);
        }

        public static T Modify<T>(this T input, Func<T, T> func) where T : class
        {
            return func.Invoke(input);
        }

        public static T Modify<T>(this ref T input, Func<T, T> func) where T : struct
        {
            return func.Invoke(input);
        }
    }
}
