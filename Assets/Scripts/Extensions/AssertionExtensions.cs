using System;
using System.Collections.Generic;
using ESparrow.Utils.Assertions;
using Object = UnityEngine.Object;

namespace ESparrow.Utils.Extensions
{
    /// <summary>
    /// Польза этого класса может показаться сомнительной (хоть в действительности так и есть), но
    /// Чтобы не загромождать всплывающее окно IDE методами расширений из класса принудительно в случае, если
    /// Пользователь подключит пространство имён ESparrow.Utils.Assertions, я дам ему возможность сделать то же самое 
    /// Самостоятельно, подключив ESparrow.Utils.Extensions.
    /// Простыми словами, данный класс просто создаёт альтернативу обычным методам из AssertionProvider в качестве методов расширения.
    /// </summary>
    public static class AssertionExtensions
    {
        public static Assertion IsTrue(this bool self, Object context = default, Action onAssert = default)
        {
            return AssertionProvider.IsTrue(self, context, onAssert);
        }

        public static Assertion IsTrue(this Func<bool> func, Object context = default, Action onAssert = default)
        {
            return AssertionProvider.IsTrue(func, context, onAssert);
        }

        public static Assertion IsMatch<T>(this T self, Predicate<T> predicate, Object context = default, Action onAssert = default)
        {
            return AssertionProvider.IsMatch(self, predicate, context, onAssert);
        }

        public static Assertion IsDefault(this object self, Object context = default, Action onAssert = default)
        {
            return AssertionProvider.IsDefault(self, context, onAssert);
        }

        public static Assertion IsEmpty(this string self, Object context = default, Action onAssert = default)
        {
            return AssertionProvider.IsEmpty(self, context, onAssert);
        }

        public static Assertion IsDefaultOrEmpty(this string self, Object context = default, Action onAssert = default)
        {
            return AssertionProvider.IsDefault(self, context, onAssert);
        }

        public static Assertion IsMoreThan
        (
            this IComparable self,
            IComparable than,
            Object context = default,
            Action onAssert = default
        )
        {
            return AssertionProvider.IsMoreThan(self, than, context, onAssert);
        }

        public static Assertion IsMoreThan<T>
        (
            this T self,
            T than,
            IComparer<T> comparer,
            Object context = default,
            Action onAssert = default
        )
        {
            return AssertionProvider.IsMoreThan(self, than, comparer, context, onAssert);
        }

        public static Assertion IsMoreOrEquals
        (
            this IComparable self,
            IComparable than,
            Object context = default,
            Action onAssert = default
        )
        {
            return AssertionProvider.IsMoreOrEquals(self, than, context, onAssert);
        }

        public static Assertion IsMoreOrEquals<T>
        (
            this T self,
            T than,
            IComparer<T> comparer,
            Object context = default,
            Action onAssert = default
        )
        {
            return AssertionProvider.IsMoreOrEquals(self, than, comparer, context, onAssert);
        }

        public static Assertion IsLessThan
        (
            this IComparable self,
            IComparable than,
            Object context = default,
            Action onAssert = default
        )
        {
            return AssertionProvider.IsLessThan(self, than, context, onAssert);
        }

        public static Assertion IsLessThan<T>
        (
            this T self,
            T than,
            IComparer<T> comparer,
            Object context = default,
            Action onAssert = default
        )
        {
            return AssertionProvider.IsLessThan(self, than, comparer, context, onAssert);
        }

        public static Assertion IsLessOrEquals
        (
            this IComparable self,
            IComparable than,
            Object context = default,
            Action onAssert = default
        )
        {
            return AssertionProvider.IsLessOrEquals(self, than, context, onAssert);
        }

        public static Assertion IsLessOrEquals<T>
        (
            this T self,
            T than,
            IComparer<T> comparer,
            Object context = default,
            Action onAssert = default
        )
        {
            return AssertionProvider.IsLessOrEquals(self, than, comparer, context, onAssert);
        }

        public static Assertion IsEquals<T>(this T self, T than, Object context = default, Action onAssert = default)
        {
            return AssertionProvider.IsEquals(self, than, context, onAssert);
        }

        public static Assertion IsEquals<T>
        (
            this T self,
            T than,
            IComparer<T> comparer,
            Object context = default,
            Action onAssert = default
        )
        {
            return AssertionProvider.IsEquals(self, than, comparer, context, onAssert);
        }
    }
}
