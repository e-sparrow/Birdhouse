using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ESparrow.Utils.Exceptions;
using UnityEngine;
using Random = System.Random;

namespace ESparrow.Utils.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Gets a random element of enumerable.
        /// </summary>
        /// <param name="enumerable">Enumerable to get an element</param>
        /// <typeparam name="T">Type of elements in enumerable</typeparam>
        /// <returns>Random element</returns>
        public static T GetRandom<T>(this IEnumerable<T> enumerable)
        {
            var array = enumerable.ToArray();
            return array[UnityEngine.Random.Range(0, array.Length)];
        }

        /// <summary>
        /// Gets a random element given its weight.
        /// </summary>
        /// <param name="enumerable">Enumerable to get an element</param>
        /// <param name="weight">Method to get weights of elements</param>
        /// <typeparam name="T">Type of elements in enumerable</typeparam>
        /// <returns>Random element</returns>
            /// <exception cref="Exception">Random double was more than sum of the weights</exception>
            public static T GetWeighedRandom<T>(this IEnumerable<T> enumerable, Func<T, double> weight)
            {
                var array = enumerable.ToArray();
                var sum = array.Sum(weight);
                
                double random = UnityEngine.Random.Range(0f, (float) sum);

                foreach (var element in array)
                {
                    random -= weight(element);
                    if (random <= 0)
                    {
                        return element;
                    }
                }

                throw new WtfException();
            }

        /// <summary>
        /// Gets specified count of not repeating random elements. 
        /// </summary>
        /// <param name="enumerable">Enumerable to get random elements</param>
        /// <param name="count">Count of random elements</param>
        /// <param name="result">Enumerable of non repeating random elements</param>
        /// <typeparam name="T">Type of elements in enumerable</typeparam>
        /// <returns>Enumerable of elements</returns>
        public static bool TryGetNonRepeatingRandom<T>(this IEnumerable<T> enumerable, int count, out IEnumerable<T> result)
        {
            result = Enumerable.Empty<T>();
            
            if (enumerable.HasNonRepeating(count, out var distinct))
            {
                distinct = distinct.Shuffle();
                result = distinct.Take(count);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets specified count of not repeating random elements given its weights.
        /// </summary>
        /// <param name="enumerable">Enumerable to get random elements</param>
        /// <param name="count">Count of random elements</param>
        /// <param name="weight">Method to get weights of elements</param>
        /// <typeparam name="T">Type of elements in enumerable</typeparam>
        /// <returns>Enumerable of elements</returns>
        /// <exception cref="Exception"></exception>
        public static IEnumerable<T> GetNonRepeatingWeighedRandom<T>(this IEnumerable<T> enumerable, int count, Func<T, double> weight)
        {
            if (enumerable.HasNonRepeating(count, out var distinct))
            {
                var used = new List<T>();
                for (int i = 0; i < count; i++)
                {
                    used.Add(distinct.Except(used).GetWeighedRandom(weight));
                }

                return used;
            }

            throw new Exception();
        }
        
        /// <summary>
        /// Aggregates action in both enumerables.
        /// </summary>
        /// <param name="self">First enumerable to aggregate</param>
        /// <param name="other">Second enumerable to aggregate</param>
        /// <param name="action">Action to execute</param>
        /// <typeparam name="T1">Type of elements in first enumerable</typeparam>
        /// <typeparam name="T2">Type of elements in second enumerable</typeparam>
        public static void CrossAggregate<T1, T2>(this IEnumerable<T1> self, IEnumerable<T2> other, Action<T1, T2> action)
        {
            var left = self.ToArray();
            var right = other.ToArray();

            int minCount = Math.Min(left.Length, right.Length);

            for (int i = 0; i < minCount; i++)
            {
                action.Invoke(left[i], right[i]);
            }
        }

        /// <summary>
        /// Swaps elements in the collection
        /// </summary>
        /// <param name="enumerable">Enumerable to swap</param>
        /// <param name="left">First element to swap</param>
        /// <param name="right">Second element to swap</param>
        /// <typeparam name="T">Type of elements in enumerable</typeparam>
        /// <returns>Enumerable with swapped elements</returns>
        /// <exception cref="Exception">Wrong index</exception>
        public static IEnumerable<T> Swap<T>(this IEnumerable<T> enumerable, T left, T right) where T : IEnumerable<T>
        {
            Validate();

            var list = enumerable.ToList();

            int leftIndex = list.IndexOf(left);
            int rightIndex = list.IndexOf(right);

            (list[leftIndex], list[rightIndex]) = (list[rightIndex], list[leftIndex]);

            return list;

            void Validate()
            {
                if (!enumerable.Contains(left))
                {
                    throw new Exception($"collection doesn't contains left");
                }

                if (!enumerable.Contains(right))
                {
                    throw new Exception($"collection doesn't contains right");
                }
            }
        }

        /// <summary>
        /// Shuffles the enumerable by default random.
        /// </summary>
        /// <param name="enumerable">Enumerable to shuffle</param>
        /// <typeparam name="T">Type of elements in enumerable</typeparam>
        /// <returns>Shuffled enumerable</returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> enumerable)
        {
            var random = new Random();
            return enumerable.Shuffle(random);
        }

        /// <summary>
        /// Shuffles the enumerable by random with specified seed.
        /// </summary>
        /// <param name="enumerable">Enumerable to shuffle</param>
        /// <param name="seed">Specified seed to random which doing a shuffle</param>
        /// <typeparam name="T">Type of elements in enumerable</typeparam>
        /// <returns>Shuffled enumerable</returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> enumerable, int seed)
        {
            var random = new Random(seed);
            return enumerable.Shuffle(random);
        }

        /// <summary>
        /// Shuffles the enumerable by specified random.
        /// </summary>
        /// <param name="enumerable">Enumerable to shuffle</param>
        /// <param name="random">Specified random which doing a shuffle</param>
        /// <typeparam name="T">Type of elements in enumerable</typeparam>
        /// <returns>Shuffled enumerable</returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> enumerable, Random random)
        {
            return enumerable.OrderBy(_ => random.Next());
        }

        /// <summary>
        /// Returns specified count of last elements of the enumerable.
        /// </summary>
        /// <param name="enumerable">Enumerable to get last elements</param>
        /// <param name="count">Count of elements to return</param>
        /// <param name="result">Last elements of enumerable</param>
        /// <typeparam name="T">Type of elements in enumerable</typeparam>
        /// <returns>True if count is correct and false otherwise</returns>
        public static bool TryGetLast<T>(this IEnumerable<T> enumerable, int count, out IEnumerable<T> result)
        {
            result = Enumerable.Empty<T>();
            
            if (enumerable.Count() >= count)
            {
                result = enumerable.Reverse().Take(count);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Removes the second enumerable from first one.
        /// </summary>
        /// <param name="enumerable">Outer enumerable</param>
        /// <param name="without">Enumerable to remove</param>
        /// <typeparam name="T">Type of elements in enumerable</typeparam>
        /// <returns>Returns first enumerable but without all the last values</returns>
        public static IEnumerable<T> Without<T>(this IEnumerable<T> enumerable, IEnumerable<T> without)
        {
            return enumerable.Where(value => !without.Contains(value));
        }

        /// <summary>
        /// Removes the second enumerable from first one.
        /// </summary>
        /// <param name="enumerable">Outer enumerable</param>
        /// <param name="without">Enumerable to remove</param>
        /// <typeparam name="T">Type of elements in enumerable</typeparam>
        /// <returns>Returns first enumerable but without all the last values</returns>
        public static IEnumerable<T> Without<T>(this IEnumerable<T> enumerable, params T[] without)
        {
            return enumerable.Where(value => !without.Contains(value));
        }

        /// <summary>
        /// Removes the same elements from enumerable by comparison.
        /// </summary>
        /// <param name="enumerable">Enumerable to distinct</param>
        /// <param name="comparison">Comparison to compare elements</param>
        /// <typeparam name="T">Type of elements in enumerable</typeparam>
        /// <returns>New enumerable without same elements</returns>
        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> enumerable, Comparison<T> comparison)
        {
            var list = enumerable.ToList();
            foreach (var self in enumerable)
            {
                foreach (var other in list.Without(self))
                {
                    if (comparison.Invoke(self, other) == 0)
                    {
                        list.Remove(other);
                    }
                }
            }

            return list.AsEnumerable();
        }

        /// <summary>
        /// Removes the same elements from enumerable by Func.
        /// </summary>
        /// <param name="enumerable">Enumerable to distinct</param>
        /// <param name="func">Func to compare elements</param>
        /// <typeparam name="T">Type of elements in enumerable</typeparam>
        /// <returns>New enumerable without same elements</returns>
        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> enumerable, Func<T, int> func)
        {
            return enumerable.Distinct((left, right) => func(right) - func(left));
        }

        /// <summary>
        /// Returns a enumerable from variable.
        /// </summary>
        /// <param name="self">Variable to create enumerable</param>
        /// <typeparam name="T">Type of variable</typeparam>
        /// <returns>Enumerable from variable</returns>
        public static IEnumerable<T> AsSingleEnumerable<T>(this T self)
        {
            var array = new T[1]
            {
                self
            };

            return array.AsEnumerable();
        }

        /// <summary>
        /// Returns enumerable without specified element.
        /// </summary>
        /// <param name="enumerable">Enumerable to remove element</param>
        /// <param name="element">Element to remove from enumerable</param>
        /// <typeparam name="T">Type of elements in enumerable</typeparam>
        /// <returns>Enumerable without specified element</returns>
        public static IEnumerable<T> Without<T>(this IEnumerable<T> enumerable, T element)
        {
            return enumerable.Except(element.AsSingleEnumerable());
        }    

        /// <summary>
        /// Checks all the other enumerable is contains in self.
        /// </summary>
        /// <param name="self">Self enumerable</param>
        /// <param name="other">Another enumerable</param>
        /// <typeparam name="T">Type of elements in enumerables</typeparam>
        /// <returns>True if all the other enumerable contains in self</returns>
        public static bool ContainsAll<T>(this IEnumerable<T> self, IEnumerable<T> other)
        {
            return self.Intersect(other).Equals(other);
        }

        /// <summary>
        /// Removes all the default values from enumerable.
        /// </summary>
        /// <param name="enumerable">Enumerable to remove default values</param>
        /// <typeparam name="T">Type of elements in enumerable</typeparam>
        /// <returns>Enumerable without default values</returns>
        public static IEnumerable<T> WithoutDefault<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.Where(value => !value.Equals(default));
        }

        /// <summary>
        /// Adds specified element to enumerable.
        /// </summary>
        /// <param name="enumerable">Enumerable to add an element</param>
        /// <param name="element">Element to add in the enumerable</param>
        /// <typeparam name="T">Type of elements in enumerable</typeparam>
        /// <returns>Enumerable with specified element</returns>
        public static IEnumerable<T> With<T>(this IEnumerable<T> enumerable, T element)
        {
            return enumerable.Concat(element.AsSingleEnumerable());
        }
        
        /// <summary>
        /// Creates enumerable from two variables.
        /// </summary>
        /// <param name="self">Self variable</param>
        /// <param name="other">Another variable</param>
        /// <typeparam name="T">Type of variables</typeparam>
        /// <returns>Enumerable with both elements</returns>
        public static IEnumerable<T> ConcatWith<T>(this T self, T other) 
        {
            return self.AsSingleEnumerable().With(other);
        }

        /// <summary>
        /// Adds variable to enumerable.
        /// </summary>
        /// <param name="self">Self enumerable</param>
        /// <param name="other">Another element</param>
        /// <typeparam name="T">Type of elements in enumerable</typeparam>
        /// <returns>Enumerable with old elements and specified variable</returns>
        public static IEnumerable<T> ConcatWith<T>(this IEnumerable<T> self, T other)
        {
            return self.Concat(other.AsSingleEnumerable());
        }

        /// <summary>
        /// Adds self variable to another enumerable.
        /// </summary>
        /// <param name="self">Self variable</param>
        /// <param name="other">Another enumerable</param>
        /// <typeparam name="T">Type of elements in enumerable</typeparam>
        /// <returns>Enumerable with old elements and specified variable</returns>
        public static IEnumerable<T> ConcatTo<T>(this T self, IEnumerable<T> other)
        {
            return self.AsSingleEnumerable().Concat(other);
        }

        /// <summary>
        /// Creates Collection from Enumerable.
        /// </summary>
        /// <param name="self">Self enumerable</param>
        /// <typeparam name="T">Type of elements in enumerable</typeparam>
        /// <returns>Collection from IEnumerable</returns>
        public static Collection<T> AsCollection<T>(this IEnumerable<T> self)
        {
            return new Collection<T>(self.ToList());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="comparison"></param>
        /// <param name="combinations"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool TryGetSameSequences<T>
        (
            this IEnumerable<T> enumerable,
            Comparison<T> comparison,
            out IEnumerable<IEnumerable<T>> combinations
        )
        {
            var list = new List<IEnumerable<T>>();

            foreach (var current in enumerable)
            {
                var combination = enumerable.Where(value => comparison.Invoke(current, value) == 0);

                if (combination != null && combination.Count() != 0)
                {
                    list.Add(combination);
                }
            }

            combinations = list;

            return list.Count > 0;
        }

        /// <summary>
        /// Gets the sequence with same elements.
        /// </summary>
        /// <param name="enumerable">Enumerable to get same elements</param>
        /// <param name="combinations">Enumerables from enumerables without same elements</param>
        /// <typeparam name="T">Type of elements in enumerable</typeparam>
        /// <returns>Enumerable with same elements</returns>
        public static bool TryGetSameSequences<T>
        (
            this IEnumerable<T> enumerable,
            out IEnumerable<IEnumerable<T>> combinations
        )
        {
            var list = new List<IEnumerable<T>>();

            foreach (var current in enumerable)
            {
                var combination = enumerable.Where(value => current.Equals(value));

                if (combination != null && combination.Count() != 0)
                {
                    list.Add(combination);
                }
            }

            combinations = list;

            return list.Count > 0;
        }

        /// <summary>
        /// Gets the sequence with same elements.
        /// </summary>
        /// <param name="enumerable">Enumerable to get same elements</param>
        /// <param name="comparison">Comparison to compare elements</param>
        /// <param name="combination">Enumerable without same elements</param>
        /// <typeparam name="T">Type of elements in enumerable</typeparam>
        /// <returns>Enumerable with same elements</returns>
        public static bool TryGetSameSequence<T>
        (
            this IEnumerable<T> enumerable,
            Comparison<T> comparison,
            out IEnumerable<T> combination
        )
        {
            bool can = enumerable.TryGetSameSequences(comparison, out var combinations);
            combination = combinations.First();

            return can;
        }

        /// <summary>
        /// Gets the sequence with same elements.
        /// </summary>
        /// <param name="enumerable">Enumerable to get same elements</param>
        /// <param name="combination">Enumerable without same elements</param>
        /// <typeparam name="T">Type of elements in enumerable</typeparam>
        /// <returns>Enumerable with same elements</returns>
        public static bool TryGetSameSequence<T>
        (
            this IEnumerable<T> enumerable,
            out IEnumerable<T> combination
        )
        {
            combination = new List<T>();

            foreach (var current in enumerable)
            {
                combination = enumerable.Where(value => current.Equals(value));

                if (combination != null && combination.Count() != 0) return true;
            }

            return false;
        }
            
        /// <summary>
        /// Gets the sequence with same elements.
        /// </summary>
        /// <param name="enumerable">Enumerable to get same elements</param>
        /// <param name="count">Count of combination</param>
        /// <param name="comparison">Comparison to compare elements</param>
        /// <param name="combination">Enumerable without same elements</param>
        /// <typeparam name="T">Type of elements in enumerable</typeparam>
        /// <returns>Enumerable with same elements</returns>
        public static bool TryGetSameSequence<T>
        (
            this IEnumerable<T> enumerable,
            int count,
            Comparison<T> comparison,
            out IEnumerable<T> combination
        )
        {
            return enumerable.TryGetSameSequence(comparison, out combination) && combination.Count() >= count;
        }

        /// <summary>
        /// Gets the sequence with same elements.
        /// </summary>
        /// <param name="enumerable">Enumerable to get same elements</param>
        /// <param name="comparison">Comparison to compare elements</param>
        /// <typeparam name="T">Type of elements in enumerable</typeparam>
        /// <returns>Enumerable with same elements</returns>
        public static IEnumerable<T> GetSameSequence<T>
        (
            this IEnumerable<T> enumerable,
            Comparison<T> comparison
        )
        {
            var _ = enumerable.TryGetSameSequence(0, comparison, out var combination);
            return combination;
        }

        /// <summary>
        /// Checks is self enumerable contains any elements which matches to predicate.
        /// </summary>
        /// <param name="self">Self enumerable</param>
        /// <param name="predicate">Specified predicate</param>
        /// <param name="first">First value which match to predicate</param>
        /// <typeparam name="T">Type of elements in enumerable</typeparam>
        /// <returns>True if enumerable is contains any elements which matches to predicate and false otherwise</returns>
        public static bool Any<T>(this IEnumerable<T> self, Predicate<T> predicate, out T first)
        {
            var func = predicate.ToFunc();
            return self.Any(func, out first);
        }

        /// <summary>
        /// Checks is self enumerable contains any elements which matches to predicate.
        /// </summary>
        /// <param name="self">Self enumerable</param>
        /// <param name="predicate">Specified predicate</param>
        /// <param name="areMatch">All the values which matches to predicate</param>
        /// <typeparam name="T">Type of elements in enumerable</typeparam>
        /// <returns>True if enumerable is contains any elements which matches to predicate and false otherwise</returns>
        public static bool Any<T>(this IEnumerable<T> self, Predicate<T> predicate, out IEnumerable<T> areMatch)
        {
            var func = predicate.ToFunc();
            return self.Any(func, out areMatch);
        }

        /// <summary>
        /// Checks is self enumerable contains any elements which matches to predicate.
        /// </summary>
        /// <param name="self">Self enumerable</param>
        /// <param name="predicate">Specified predicate</param>
        /// <param name="first">First value which match to predicate</param>
        /// <typeparam name="T">Type of elements in enumerable</typeparam>
        /// <returns>True if enumerable is contains any elements which matches to predicate and false otherwise</returns>
        public static bool Any<T>(this IEnumerable<T> self, Func<T, bool> predicate, out T first)
        {
            first = default;
            if (!self.Any(predicate)) return false;

            first = self.First(predicate);
            return true;
        }

        /// <summary>
        /// Checks is self enumerable contains any elements which matches to predicate.
        /// </summary>
        /// <param name="self">Self enumerable</param>
        /// <param name="predicate">Specified predicate</param>
        /// <param name="areMatch">All the values which matches to predicate</param>
        /// <typeparam name="T">Type of elements in enumerable</typeparam>
        /// <returns>True if enumerable is contains any elements which matches to predicate and false otherwise</returns>
        public static bool Any<T>(this IEnumerable<T> self, Func<T, bool> predicate, out IEnumerable<T> areMatch)
        {
            areMatch = default;
            if (!self.Any(predicate)) return false;

            areMatch = self.Where(predicate);
            return true;
        }

        /// <summary>
        /// Checks for count of not repeating elements.
        /// </summary>
        /// <param name="enumerable">Enumerable for check</param>
        /// <param name="count">Count of not repeating elements</param>
        /// <param name="distinctFunc">Function to distinct enumerable</param>
        /// <param name="distinct">Enumerable without same elements</param>
        /// <typeparam name="T">Type of elements in enumerable</typeparam>
        /// <returns>True if count of not repeating elements is more than specified count and false otherwise</returns>
        private static bool HasNonRepeating<T>(this IEnumerable<T> enumerable, int count, Func<IEnumerable<T>, IEnumerable<T>> distinctFunc, out IEnumerable<T> distinct)
        {
            distinct = distinctFunc.Invoke(enumerable);

            if (count > enumerable.Count()) return false;

            var isCorrect = count >= distinct.Count();
            return isCorrect;
        }

        /// <summary>
        /// Checks for count of not repeating elements.
        /// </summary>
        /// <param name="enumerable">Enumerable for check</param>
        /// <param name="count">Count of not repeating elements</param>
        /// <param name="distinct">Enumerable without same elements</param>
        /// <typeparam name="T">Type of elements in enumerable</typeparam>
        /// <returns>True if count of not repeating elements is more than specified count and false otherwise</returns>
        private static bool HasNonRepeating<T>(this IEnumerable<T> enumerable, int count, out IEnumerable<T> distinct)
        {
            return HasNonRepeating(enumerable, count, Enumerable.Distinct, out distinct);
        }
    }
}
