using System;
using System.Linq;

namespace Birdhouse.Common.Helpers
{
    public static class DelegateHelper
    {
        /// <summary>
        /// Returns new function that return true if all the specific predicates return true.
        /// </summary>
        /// <param name="predicates">Specific predicates</param>
        /// <typeparam name="T">Type of subject to validate</typeparam>
        /// <returns>Concatenated function</returns>
        public static Func<T, bool> All<T>(params Func<T, bool>[] predicates)
        {
            return subject => predicates.All(value => value.Invoke(subject));
        }
        
        /// <summary>
        /// Returns new function that return true if any of the specific predicates return true.
        /// </summary>
        /// <param name="predicates">Specific predicates</param>
        /// <typeparam name="T">Type of subject to validate</typeparam>
        /// <returns>Concatenated function</returns>
        public static Func<T, bool> Any<T>(params Func<T, bool>[] predicates)
        {
            return subject => predicates.Any(value => value.Invoke(subject));
        }

        public static Func<T, T> Self<T>()
        {
            return self => self;
        }

        public static Func<object, object> Self()
        {
            return Self<object>();
        }
    }
}
