using System;
using System.Collections.Generic;
using System.Linq;
using ESparrow.Utils.Helpers;
using UnityEngine.Events;

namespace ESparrow.Utils.Extensions
{
    public static class DelegateExtensions
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
        /// Gets the function to get the value by specific value.
        /// </summary>
        /// <param name="self">The self variable to get by function</param>
        /// <typeparam name="T">Type of variable</typeparam>
        /// <returns>Function to get variable</returns>
        public static Func<T> Get<T>(this T self)
        {
            return () => self;
        }

        /// <summary>
        /// Gets the value by the function.
        /// </summary>
        /// <param name="self">Function to get the value</param>
        /// <typeparam name="T">Type of the value</typeparam>
        /// <returns>Specific value by function without arguments</returns>
        public static T Value<T>(this Func<T> self)
        {
            return self.Invoke();
        }
        
        public static Func<T, bool> All<T>(this IEnumerable<Func<T, bool>> predicates)
        {
            return DelegateHelper.All(predicates.ToArray());
        }
        
        public static Func<T, bool> Any<T>(this IEnumerable<Func<T, bool>> predicates)
        {
            return subject => predicates.Any(value => value.Invoke(subject));
        }
    }
}
