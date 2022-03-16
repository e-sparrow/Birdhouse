using System;
using System.Collections.Generic;
using System.Linq;
using ESparrow.Utils.Generalization.Errors.Interfaces;
using ESparrow.Utils.Assertions.Interfaces;
using Object = UnityEngine.Object;

namespace ESparrow.Utils.Assertions
{
    public static class AssertionProvider
    {
        private const string DefaultIsTrueErrorMessage = "Specified member isn't true";
        private const string DefaultIsDefaultErrorMessage = "Specified variable is null";
        private const string DefaultIsMatchErrorMessage = "Specified variable isn't match your predicate";

        private const string DefaultIsEmptyErrorMessage = "String is empty";
        private const string DefaultIsDefaultOrEmptyErrorMessage = "String is default or empty";

        private const string DefaultIsContainsElementMessage = "Collection doesn't contain this element";

        private const string DefaultIsMoreThanErrorMessage = "Variable is less or equals specified variable";
        private const string DefaultIsMoreOrEqualsErrorMessage = "Variable is less than specified variable";

        private const string DefaultIsLessThanErrorMessage = "Variable is more or equals specified variable";
        private const string DefaultIsLessOrEqualsErrorMessage = "Variable is more specified variable";

        private const string DefaultIsEqualsErrorMessage = "Variable is not equals specified variable";

        /// <summary>
        /// Checks is the target boolean variable is true.
        /// </summary>
        /// <param name="self">Target boolean variable</param>
        /// <param name="context">Context of assertion</param>
        /// <param name="onAssert">Callback of the assertion</param>
        /// <returns>Assertion to assert</returns>
        public static IFluentAssertion IsTrue(bool self, Object context = default, Action onAssert = default)
        {
            var assertion = new Assertion(DefaultIsTrueErrorMessage, context, () => self, onAssert);
            return assertion;
        }

        /// <summary>
        /// Checks is the target boolean function is returns true.
        /// </summary>
        /// <param name="func">Target boolean function</param>
        /// <param name="context">Context of assertion</param>
        /// <param name="onAssert">Callback of the assertion</param>
        /// <returns>Assertion to assert</returns>
        public static IFluentAssertion IsTrue(Func<bool> func, Object context = default, Action onAssert = default)
        {
            var assertion = new Assertion(DefaultIsTrueErrorMessage, context, func, onAssert);
            return assertion;
        }

        /// <summary>
        /// Checks is self value matches to specified predicate.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <param name="predicate">Specified predicate</param>
        /// <param name="context">Context of assertion</param>
        /// <param name="onAssert">Callback of the assertion</param>
        /// <typeparam name="T">Type of self value</typeparam>
        /// <returns>Assertion to assert</returns>
        public static IFluentAssertion IsMatch<T>(T self, Predicate<T> predicate, Object context = default, Action onAssert = default)
        {
            var assertion = new Assertion(DefaultIsMatchErrorMessage, context, () => predicate.Invoke(self), onAssert);
            return assertion;
        }

        /// <summary>
        /// Checks is self value is default.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <param name="context">Context of assertion</param>
        /// <param name="onAssert">Callback of the assertion</param>
        /// <returns>Assertion to assert</returns>
        public static IFluentAssertion IsDefault(object self, Object context = default, Action onAssert = default)
        {
            var assertion = new Assertion(DefaultIsDefaultErrorMessage, context, () => self.Equals(default), onAssert);
            return assertion;
        }

        /// <summary>
        /// Checks is self string value is empty.
        /// </summary>
        /// <param name="self">Self string value</param>
        /// <param name="context">Context of assertion</param>
        /// <param name="onAssert">Callback of the assertion</param>
        /// <returns>Assertion to assert</returns>
        public static IFluentAssertion IsEmpty(string self, Object context = default, Action onAssert = default)
        {
            var assertion = new Assertion(DefaultIsEmptyErrorMessage, context, () => self.Equals(string.Empty), onAssert);
            return assertion;
        }

        /// <summary>
        /// Checks is self string value is null or empty.
        /// </summary>
        /// <param name="self">Self string value</param>
        /// <param name="context">Context of assertion</param>
        /// <param name="onAssert">Callback of the assertion</param>
        /// <returns>Assertion to assert</returns>
        public static IFluentAssertion IsNullOrEmpty(string self, Object context = default, Action onAssert = default)
        {
            var assertion = new Assertion(DefaultIsDefaultOrEmptyErrorMessage, context, () => string.IsNullOrEmpty(self), onAssert);
            return assertion;
        }

        /// <summary>
        /// Checks is self enumerable contains specified element.
        /// </summary>
        /// <param name="enumerable">Self enumerable</param>
        /// <param name="element">Specified element</param>
        /// <param name="context">Context of assertion</param>
        /// <param name="onAssert">Callback of the assertion</param>
        /// <typeparam name="T">Type of self value</typeparam>
        /// <returns>Assertion to assert</returns>
        public static IFluentAssertion IsContains<T>(IEnumerable<T> enumerable, T element, Object context = default, Action onAssert = default)
        {
            var assertion = new Assertion(DefaultIsContainsElementMessage, context, () => enumerable.Contains(element), onAssert);
            return assertion;
        }

        /// <summary>
        /// Checks is self value more than another one.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <param name="other">Another one</param>
        /// <param name="context">Context of assertion</param>
        /// <param name="onAssert">Callback of the assertion</param>
        /// <returns>Assertion to assert</returns>
        public static IFluentAssertion IsMoreThan
        (
            IComparable self, 
            IComparable other, 
            Object context = default, 
            Action onAssert = default
        )
        {
            var assertion = new Assertion(DefaultIsMoreThanErrorMessage, context, () => self.CompareTo(other) > 0, onAssert);
            return assertion;
        }

        /// <summary>
        /// Checks is self value more than another one.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <param name="other">Another one</param>
        /// <param name="comparer">Comparer to compare self and another values</param>
        /// <param name="context">Context of assertion</param>
        /// <param name="onAssert">Callback of the assertion</param>
        /// <typeparam name="T">Type of self value</typeparam>
        /// <returns>Assertion to assert</returns>
        public static IFluentAssertion IsMoreThan<T>
        (
            T self,
            T other,
            IComparer<T> comparer,
            Object context = default,
            Action onAssert = default
        )
        {
            var assertion = new Assertion(DefaultIsMoreThanErrorMessage, context, () => comparer.Compare(self, other) > 0, onAssert);
            return assertion;
        }

        /// <summary>
        /// Checks is self value more or equals another one.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <param name="other">Another one</param>
        /// <param name="context">Context of assertion</param>
        /// <param name="onAssert">Callback of the assertion</param>
        /// <returns>Assertion to assert</returns>
        public static IFluentAssertion IsMoreOrEquals
        (
            IComparable self, 
            IComparable other, 
            Object context = default, 
            Action onAssert = default
        )
        {
            var assertion = new Assertion(DefaultIsMoreOrEqualsErrorMessage, context, () => self.CompareTo(other) >= 0, onAssert);
            return assertion;
        }

        /// <summary>
        /// Checks is self value more or equals another one.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <param name="other">Another one</param>
        /// <param name="comparer">Comparer to compare self and another values</param>
        /// <param name="context">Context of assertion</param>
        /// <param name="onAssert">Callback of the assertion</param>
        /// <typeparam name="T">Type of self value</typeparam>
        /// <returns>Assertion to assert</returns>
        public static IFluentAssertion IsMoreOrEquals<T>
        (
            T self,
            T other,
            IComparer<T> comparer,
            Object context = default,
            Action onAssert = default
        )
        {
            var assertion = new Assertion(DefaultIsMoreOrEqualsErrorMessage, context, () => comparer.Compare(self, other) >= 0, onAssert);
            return assertion;
        }

        /// <summary>
        /// Checks is self value less than another one.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <param name="other">Another one</param>
        /// <param name="context">Context of assertion</param>
        /// <param name="onAssert">Callback of the assertion</param>
        /// <returns>Assertion to assert</returns>
        public static IFluentAssertion IsLessThan
        (
            IComparable self,
            IComparable other, 
            Object context = default, 
            Action onAssert = default
        )
        {
            var assertion = new Assertion(DefaultIsLessThanErrorMessage, context, () => self.CompareTo(other) < 0, onAssert);
            return assertion;
        }

        /// <summary>
        /// Checks is self value less than another one.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <param name="other">Another one</param>
        /// <param name="comparer">Comparer to compare self and another values</param>
        /// <param name="context">Context of assertion</param>
        /// <param name="onAssert">Callback of the assertion</param>
        /// <typeparam name="T">Type of self value</typeparam>
        /// <returns>Assertion to assert</returns>
        public static IFluentAssertion IsLessThan<T>
        (
            T self,
            T other,
            IComparer<T> comparer,
            Object context = default,
            Action onAssert = default
        )
        {
            var assertion = new Assertion(DefaultIsLessThanErrorMessage, context, () => comparer.Compare(self, other) < 0, onAssert);
            return assertion;
        }

        /// <summary>
        /// Checks is self value less or equals another one.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <param name="other">Another one</param>
        /// <param name="context">Context of assertion</param>
        /// <param name="onAssert">Callback of the assertion</param>
        /// <returns>Assertion to assert</returns>
        public static IFluentAssertion IsLessOrEquals
        (
            IComparable self, 
            IComparable other, 
            Object context = default, 
            Action onAssert = default
        )
        {
            var assertion = new Assertion(DefaultIsLessOrEqualsErrorMessage, context, () => self.CompareTo(other) <= 0, onAssert);
            return assertion;
        }

        /// <summary>
        /// Checks is self value less or equals another one.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <param name="other">Another one</param>
        /// <param name="comparer">Comparer to compare self and another values</param>
        /// <param name="context">Context of assertion</param>
        /// <param name="onAssert">Callback of the assertion</param>
        /// <typeparam name="T">Type of self value</typeparam>
        /// <returns>Assertion to assert</returns>
        public static IFluentAssertion IsLessOrEquals<T>
        (
            T self,
            T other,
            IComparer<T> comparer,
            Object context = default,
            Action onAssert = default
        )
        {
            var assertion = new Assertion(DefaultIsLessOrEqualsErrorMessage, context, () => comparer.Compare(self, other) <= 0, onAssert);
            return assertion;
        }

        /// <summary>
        /// Checks is self value equals another one.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <param name="other">Another one</param>
        /// <param name="context">Context of assertion</param>
        /// <param name="onAssert">Callback of the assertion</param>
        /// <typeparam name="T"></typeparam>
        /// <returns>Assertion to assert</returns>
        public static IFluentAssertion IsEquals<T>(T self, T other, Object context = default, Action onAssert = default)
        {
            var assertion = new Assertion(DefaultIsEqualsErrorMessage, context, () => self.Equals(other), onAssert);
            return assertion;
        }

        /// <summary>
        /// Checks is self value equals another one.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <param name="other">Another one</param>
        /// <param name="comparer">Comparer to compare self and another values</param>
        /// <param name="context">Context of assertion</param>
        /// <param name="onAssert">Callback of the assertion</param>
        /// <typeparam name="T">Type of self and another values</typeparam>
        /// <returns>Assertion to assert</returns>
        public static IFluentAssertion IsEquals<T>
        (
            T self, 
            T other, 
            IComparer<T> comparer, 
            Object context = default, 
            Action onAssert = default
        )
        {
            var assertion = new Assertion(DefaultIsEqualsErrorMessage, context, () => comparer.Compare(self, other) == 0, onAssert);
            return assertion;
        }

        /// <summary>
        /// Checks is self value equals another one with specified error.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <param name="other">Another one</param>
        /// <param name="error">Specified error</param>
        /// <param name="context">Context of assertion</param>
        /// <param name="onAssert">Callback of the assertion</param>
        /// <typeparam name="T">Type of self and another values</typeparam>
        /// <returns>Assertion to assert</returns>
        public static IFluentAssertion IsEqualsWithError<T>
        (
            IErroneous<T> self,
            T other,
            T error = default,
            Object context = default,
            Action onAssert = default
        )
        {
            if (error.Equals(default))
            {
                error = self.DefaultError;
            }
            
            var assertion = new Assertion(DefaultIsEqualsErrorMessage, context, () => self.CompareWithError(other, error), onAssert);
            return assertion;
        }
    }
}
