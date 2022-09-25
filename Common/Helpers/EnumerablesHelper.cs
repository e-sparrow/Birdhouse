using System;
using System.Collections.Generic;
using System.Linq;

namespace Birdhouse.Common.Helpers
{
    public static class EnumerablesHelper
    {
        public static IEnumerable<TResult> ForEachResult<TInput, TResult>(IEnumerable<TInput> collection, Func<TInput, TResult> func)
        {
            var list = new List<TResult>();
            foreach (var input in collection)
            {
                list.Add(func.Invoke(input));
            }

            return list.AsEnumerable();
        }

        public static IEnumerable<T> For<T>(Func<int, T> func, int count)
        {
            var list = new List<T>();

            for (int i = 0; i < count; i++)
            {
                list.Add(func(i));
            }

            return list.AsEnumerable();
        }

        /// <summary>
        /// Gets the result of repeating of specific function for specific times.
        /// </summary>
        /// <param name="func">Specific function to repeat with argument from 0 to count</param>
        /// <param name="count">Count to repeat</param>
        /// <typeparam name="T">Type of function's result</typeparam>
        /// <returns>Enumerable with the result of repeating</returns>
        public static IEnumerable<T> RepeatWithResult<T>(Func<int, T> func, int count)
        {
            var list = new List<T>();
            for (int i = 0; i < count; i++)
            {
                list.Add(func.Invoke(i));
            }

            return list;
        }

        /// <summary>
        /// Gets the result of repeating of specific function for specific times.
        /// </summary>
        /// <param name="func">Specific function to repeat</param>
        /// <param name="count">Count to repeat</param>
        /// <typeparam name="T">Type of function's result</typeparam>
        /// <returns>Enumerable with the result of repeating</returns>
        public static IEnumerable<T> RepeatWithResult<T>(Func<T> func, int count)
        {
            return RepeatWithResult(_ => func.Invoke(), count);
        }
    }
}
