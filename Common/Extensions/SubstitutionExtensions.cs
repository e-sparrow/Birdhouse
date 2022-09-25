using System.Collections.Generic;
using Birdhouse.Common.Helpers;
using Birdhouse.Tools.Substitution.Interfaces;

namespace Birdhouse.Common.Extensions
{
    public static class SubstitutionExtensions
    {
        public static ISubstitutionOperator<T> AsSubstitutionOperator<T>(this IList<T> list)
        {
            return SubstitutionHelper.CreateSubstitutionOperator(list);
        }

        public static ISubstitutionOperator<KeyValuePair<TKey, TValue>> AsSubstitutionOperator<TKey, TValue>
            (this IDictionary<TKey, TValue> dictionary)
        {
            return SubstitutionHelper.CreateSubstitutionOperator(dictionary);
        }
    }
}