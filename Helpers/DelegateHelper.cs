using System;
using System.Collections.Generic;
using System.Linq;

namespace ESparrow.Utils.Helpers
{
    public class DelegateHelper
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
    }
}
