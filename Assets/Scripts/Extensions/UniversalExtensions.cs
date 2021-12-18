using System;
using System.Collections.Generic;

namespace ESparrow.Utils.Extensions
{
    public static class UniversalExtensions
    {
        /// <summary>
        /// Uses the element and returns it.
        /// </summary>
        /// <param name="self">Self variable.</param>
        /// <param name="action">Action to execute with element.</param>
        /// <typeparam name="T">Type of self variable</typeparam>
        /// <returns>Same variable</returns>
        public static T Use<T>(this T self, Action<T> action)
        {
            action.Invoke(self);
            return self;
        }

        /// <summary>
        /// Gets the TOut in the TIn variable.
        /// </summary>
        /// <param name="self">Self variable</param>
        /// <param name="func">Func to get something</param>
        /// <typeparam name="TIn">Self variable type</typeparam>
        /// <typeparam name="TOut">Variable to get type</typeparam>
        /// <returns>Result of a Func</returns>
        public static TOut Get<TIn, TOut>(this TIn self, Func<TIn, TOut> func)
        {
            return func.Invoke(self);
        }

        /// <summary>
        /// Modifies a variable by func and returns it.
        /// </summary>
        /// <param name="self">Variable to modify</param>
        /// <param name="func">Func to modify</param>
        /// <typeparam name="T">Type of variable</typeparam>
        /// <returns>Same variable</returns>
        public static T Modify<T>(this T self, Func<T, T> func)
        {
            return func.Invoke(self);
        }

        public static T Modify<T>(this T self, Action<T> action)
        {
            action.Invoke(self);
            return self;
        }

        /// <summary>
        /// Adds the element to collection and returns it back.
        /// </summary>
        /// <param name="element">Element to add and return</param>
        /// <param name="collection">Collection to add the element</param>
        /// <typeparam name="T">Type of elements in collection</typeparam>
        /// <returns>Element added to collection</returns>
        public static T AddTo<T>(this T element, ICollection<T> collection)
        {
            collection.Add(element);
            return element;
        }
        
        public static TResult PipeTo<TSource, TResult>(this TSource source, Func<TSource, TResult> func)
        {
            return func.Invoke(source);
        }
    }
}
