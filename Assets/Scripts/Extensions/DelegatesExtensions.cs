using System;

namespace ESparrow.Utils.Extensions
{
    public static class DelegatesExtensions
    {
        public static Comparison<T> FuncToComparison<T>(Func<T, int> func)
        {
            return (left, right) => func.Invoke(right) - func.Invoke(left);
        }

        public static Func<T, bool> PredicateToFunc<T>(Predicate<T> predicate)
        {
            return predicate as Func<T, bool>;
        }

        public static Predicate<T> FuncToPredicate<T>(Func<T, bool> func)
        {
            return func as Predicate<T>;
        }
    }
}
