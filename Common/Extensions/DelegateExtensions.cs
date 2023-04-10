using System;
using System.Collections.Generic;
using System.Linq;
using Birdhouse.Common.Helpers;
using UnityEngine.Events;

namespace Birdhouse.Common.Extensions
{
    public static class DelegateExtensions
    {
        /// <summary>
        /// Converts Func to Comparison.
        /// </summary>
        /// <param name="func">Func to convert</param>
        /// <typeparam name="T">Type to compare</typeparam>
        /// <returns>Func converted to Comparison</returns>
        public static Comparison<T> AsComparison<T>(this Func<T, int> func)
        {
            return Compare;

            int Compare(T left, T right)
            {
                var rightValue = func.Invoke(right);
                var leftValue = func.Invoke(left);
                
                var result = rightValue - leftValue;
                return result;
            }
        }

        /// <summary>
        /// Converts Predicate to Func.
        /// </summary>
        /// <param name="predicate">Predicate to convert</param>
        /// <typeparam name="T">Type to predicate</typeparam>
        /// <returns>Predicate converted to Func</returns>
        public static Func<T, bool> AsFunc<T>(this Predicate<T> predicate)
        {
            return predicate as Func<T, bool>;
        }

        /// <summary>
        /// Converts Func to Predicate.
        /// </summary>
        /// <param name="func">Func to convert</param>
        /// <typeparam name="T">Type to predicate</typeparam>
        /// <returns>Func converted to Predicate</returns>
        public static Predicate<T> AsPredicate<T>(this Func<T, bool> func)
        {
            return func as Predicate<T>;
        }

        /// <summary>
        /// Converts Action to UnityAction.
        /// </summary>
        /// <param name="action">Action to convert</param>
        /// <returns>Action converted to UnityAction</returns>
        public static UnityAction AsUnityAction(this Action action)
        {
            var result = new UnityAction(action);
            return result;
        }

        /// <summary>
        /// Converts UnityAction to Action.
        /// </summary>
        /// <param name="action">UnityAction to convert</param>
        /// <returns>UnityAction converted to Action</returns>
        public static Action AsAction(this UnityAction action)
        {
            var result = new Action(action);
            return result;
        }

        /// <summary>
        /// Gets the function to get the value by specific value.
        /// </summary>
        /// <param name="self">The self variable to get by function</param>
        /// <typeparam name="T">Type of variable</typeparam>
        /// <returns>Function to get variable</returns>
        public static Func<T> AsFunc<T>(this T self)
        {
            return GetValue;

            T GetValue()
            {
                return self;
            }
        }
        
        public static Func<T, bool> All<T>(this IEnumerable<Func<T, bool>> predicates)
        {
            return DelegateHelper.All(predicates.ToArray());
        }
        
        public static Func<T, bool> Any<T>(this IEnumerable<Func<T, bool>> predicates)
        {
            return subject => predicates.Any(value => value.Invoke(subject));
        }

        public static Predicate<T> Inverse<T>(this Predicate<T> self)
        {
            return IsFit;

            bool IsFit(T value)
            {
                var result = !self.Invoke(value);
                return result;
            }
        }

        public static Predicate<T> And<T>(this Predicate<T> self, Predicate<T> other)
        {
            return IsFit;

            bool IsFit(T value)
            {
                var left = self.Invoke(value);
                var right = other.Invoke(value);

                var result = left && right;
                return result;
            }
        }

        public static Predicate<T> AndNot<T>(this Predicate<T> self, Predicate<T> other)
        {
            return IsFit;

            bool IsFit(T value)
            {
                var left = self.Invoke(value);
                var right = other.Invoke(value);

                var result = left && !right;
                return result;
            }
        }

        public static Predicate<T> Or<T>(this Predicate<T> self, Predicate<T> other)
        {
            return IsFit;

            bool IsFit(T value)
            {
                var left = self.Invoke(value);
                var right = other.Invoke(value);

                var result = left || right;
                return result;
            }
        }

        public static Predicate<T> Xor<T>(this Predicate<T> self, Predicate<T> other)
        {
            return IsFit;

            bool IsFit(T value)
            {
                var left = self.Invoke(value);
                var right = other.Invoke(value);

                var result = left ^ right;
                return result;
            }
        }
    }
}
