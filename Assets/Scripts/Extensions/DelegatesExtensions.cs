using System;
using UnityEngine.Events;

namespace ESparrow.Utils.Extensions
{
    public static class DelegatesExtensions
    {
        /// <summary>
        /// Converts Func to Comparison.
        /// </summary>
        /// <param name="func">Func to convert</param>
        /// <typeparam name="T">Type to compare</typeparam>
        /// <returns>Func converted to Comparison</returns>
        public static Comparison<T> ToComparison<T>(this Func<T, int> func)
        {
            return (left, right) => func.Invoke(right) - func.Invoke(left);
        }

        /// <summary>
        /// Converts Predicate to Func.
        /// </summary>
        /// <param name="predicate">Predicate to convert</param>
        /// <typeparam name="T">Type to predicate</typeparam>
        /// <returns>Predicate converted to Func</returns>
        public static Func<T, bool> ToFunc<T>(this Predicate<T> predicate)
        {
            return predicate as Func<T, bool>;
        }

        /// <summary>
        /// Converts Func to Predicate.
        /// </summary>
        /// <param name="func">Func to convert</param>
        /// <typeparam name="T">Type to predicate</typeparam>
        /// <returns>Func converted to Predicate</returns>
        public static Predicate<T> ToPredicate<T>(this Func<T, bool> func)
        {
            return func as Predicate<T>;
        }

        /// <summary>
        /// Converts Action to UnityAction.
        /// </summary>
        /// <param name="action">Action to convert</param>
        /// <returns>Action converted to UnityAction</returns>
        public static UnityAction ToUnityAction(this Action action)
        {
            return new UnityAction(action);
        }

        /// <summary>
        /// Converts UnityAction to Action.
        /// </summary>
        /// <param name="action">UnityAction to convert</param>
        /// <returns>UnityAction converted to Action</returns>
        public static Action ToAction(this UnityAction action)
        {
            return new Action(action);
        }

        /// <summary>
        /// Gets the self by Func.
        /// </summary>
        /// <param name="self">The self variable to get</param>
        /// <typeparam name="T">Type of variable</typeparam>
        /// <returns>Func to get variable</returns>
        public static Func<T> Get<T>(this T self)
        {
            return () => self;
        }
    }
}
