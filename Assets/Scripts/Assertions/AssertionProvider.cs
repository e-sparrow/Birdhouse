using System;
using System.Collections.Generic;
using ESparrow.Utils.Tools.Errors.Interfaces;
using Object = UnityEngine.Object;

namespace ESparrow.Utils.Assertions
{
    public static class AssertionProvider
    {
        private const string defaultIsTrueErrorMessage = "Specified member isn't true";
        private const string defaultIsDefaultErrorMessage = "Specified variable is null";
        private const string defaultIsMatchErrorMessage = "Specified variable isn't match your predicate";

        private const string defaultIsEmptyErrorMessage = "String is empty";
        private const string defaultIsDefaultOrEmptyErrorMessage = "String is default or empty";

        private const string defaultIsMoreThanErrorMessage = "Variable is less or equals specified variable";
        private const string defaultIsMoreOrEqualsErrorMessage = "Variable is less than specified variable";

        private const string defaultIsLessThanErrorMessage = "Variable is more or equals specified variable";
        private const string defaultIsLessOrEqualsErrorMessage = "Variable is more specified variable";

        private const string defaultIsEqualsErrorMessage = "Variable is not equals specified variable";

        public static Assertion IsTrue(bool self, Object context = default, Action onAssert = default)
        {
            var assertion = new Assertion(defaultIsTrueErrorMessage, context, () => self, onAssert);
            return assertion;
        }

        public static Assertion IsTrue(Func<bool> func, Object context = default, Action onAssert = default)
        {
            var assertion = new Assertion(defaultIsTrueErrorMessage, context, func, onAssert);
            return assertion;
        }

        public static Assertion IsMatch<T>(T self, Predicate<T> predicate, Object context = default, Action onAssert = default)
        {
            var assertion = new Assertion(defaultIsMatchErrorMessage, context, () => predicate.Invoke(self), onAssert);
            return assertion;
        }

        public static Assertion IsDefault(object self, Object context = default, Action onAssert = default)
        {
            var assertion = new Assertion(defaultIsDefaultErrorMessage, context, () => self.Equals(default), onAssert);
            return assertion;
        }

        public static Assertion IsEmpty(string self, Object context = default, Action onAssert = default)
        {
            var assertion = new Assertion(defaultIsEmptyErrorMessage, context, () => self.Equals(string.Empty), onAssert);
            return assertion;
        }

        public static Assertion IsDefaultOrEmpty(string self, Object context = default, Action onAssert = default)
        {
            var assertion = new Assertion(defaultIsDefaultOrEmptyErrorMessage, context, () => string.IsNullOrEmpty(self), onAssert);
            return assertion;
        }

        public static Assertion IsMoreThan
        (
            IComparable self, 
            IComparable than, 
            Object context = default, 
            Action onAssert = default
        )
        {
            var assertion = new Assertion(defaultIsMoreThanErrorMessage, context, () => self.CompareTo(than) > 0, onAssert);
            return assertion;
        }

        public static Assertion IsMoreThan<T>
        (
            T self,
            T than,
            IComparer<T> comparer,
            Object context = default,
            Action onAssert = default
        )
        {
            var assertion = new Assertion(defaultIsMoreThanErrorMessage, context, () => comparer.Compare(self, than) > 0, onAssert);
            return assertion;
        }

        public static Assertion IsMoreOrEquals
        (
            IComparable self, 
            IComparable than, 
            Object context = default, 
            Action onAssert = default
        )
        {
            var assertion = new Assertion(defaultIsMoreOrEqualsErrorMessage, context, () => self.CompareTo(than) >= 0, onAssert);
            return assertion;
        }

        public static Assertion IsMoreOrEquals<T>
        (
            T self,
            T than,
            IComparer<T> comparer,
            Object context = default,
            Action onAssert = default
        )
        {
            var assertion = new Assertion(defaultIsMoreOrEqualsErrorMessage, context, () => comparer.Compare(self, than) >= 0, onAssert);
            return assertion;
        }

        public static Assertion IsLessThan
        (
            IComparable self,
            IComparable than, 
            Object context = default, 
            Action onAssert = default
        )
        {
            var assertion = new Assertion(defaultIsLessThanErrorMessage, context, () => self.CompareTo(than) < 0, onAssert);
            return assertion;
        }

        public static Assertion IsLessThan<T>
        (
            T self,
            T than,
            IComparer<T> comparer,
            Object context = default,
            Action onAssert = default
        )
        {
            var assertion = new Assertion(defaultIsLessThanErrorMessage, context, () => comparer.Compare(self, than) < 0, onAssert);
            return assertion;
        }

        public static Assertion IsLessOrEquals
        (
            IComparable self, 
            IComparable than, 
            Object context = default, 
            Action onAssert = default
        )
        {
            var assertion = new Assertion(defaultIsLessOrEqualsErrorMessage, context, () => self.CompareTo(than) <= 0, onAssert);
            return assertion;
        }

        public static Assertion IsLessOrEquals<T>
        (
            T self,
            T than,
            IComparer<T> comparer,
            Object context = default,
            Action onAssert = default
        )
        {
            var assertion = new Assertion(defaultIsLessOrEqualsErrorMessage, context, () => comparer.Compare(self, than) <= 0, onAssert);
            return assertion;
        }

        public static Assertion IsEquals<T>(T self, T than, Object context = default, Action onAssert = default)
        {
            var assertion = new Assertion(defaultIsEqualsErrorMessage, context, () => self.Equals(than), onAssert);
            return assertion;
        }

        public static Assertion IsEquals<T>
        (
            T self, 
            T than, 
            IComparer<T> comparer, 
            Object context = default, 
            Action onAssert = default
        )
        {
            var assertion = new Assertion(defaultIsEqualsErrorMessage, context, () => comparer.Compare(self, than) == 0, onAssert);
            return assertion;
        }

        public static Assertion IsEqualsWithError<T>
        (
            IErroneous<T> self,
            T than,
            T error = default,
            Object context = default,
            Action onAssert = default
        )
        {
            var assertion = new Assertion(defaultIsEqualsErrorMessage, context, () => self.CompareWithError(than, error), onAssert);
            return assertion;
        }
    }
}
