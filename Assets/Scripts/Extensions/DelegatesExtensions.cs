using System;
using UnityEngine.Events;

namespace ESparrow.Utils.Extensions
{
    public static class DelegatesExtensions
    {
        public static Comparison<T> ToComparison<T>(this Func<T, int> func)
        {
            return (left, right) => func.Invoke(right) - func.Invoke(left);
        }

        public static Func<T, bool> ToFunc<T>(this Predicate<T> predicate)
        {
            return predicate as Func<T, bool>;
        }

        public static Predicate<T> ToPredicate<T>(this Func<T, bool> func)
        {
            return func as Predicate<T>;
        }

        public static UnityAction ToUnityAction(this Action action)
        {
            return new UnityAction(action);
        }

        public static Action ToAction(this UnityAction unityAction)
        {
            return new Action(unityAction);
        }
    }
}
