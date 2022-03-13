using System.Collections.Generic;
using ESparrow.Utils.Helpers;
using ESparrow.Utils.Tools.Substitution.Interfaces;

namespace ESparrow.Utils.Extensions
{
    public static class SubstitutionExtensions
    {
        public static ISubstitutionOperator<T> CreateSubstitutionOperator<T>(this IList<T> list)
        {
            return SubstitutionHelper.CreateSubstitutionOperator(list);
        }
    }
}