﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace ESparrow.Utils.Extensions
{
    /// <summary>
    /// Класс расширений для коллекций, наследуемых от интерфейса IEnumerable;
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Получает случайный элемент коллекции.
        /// </summary>
        public static T GetRandom<T>(this IEnumerable<T> collection)
        {
            var array = collection.ToArray();
            return array[UnityEngine.Random.Range(0, array.Length)];
        }

        /// <summary>
        /// Получает случайный элемент из коллекции, учитывая его вес, за который можно принять любое float, int или double число.
        /// </summary>
        public static T GetWeighedRandom<T>(this IEnumerable<T> collection, Func<T, double> weight)
        {
            var array = collection.ToArray();

            double sum = array.Sum(value => weight(value));
            double random = UnityEngine.Random.Range(0f, (float) sum);

            foreach (var element in array)
            {
                random -= weight(element);
                if (random <= 0)
                {
                    return element;
                }
            }

            throw new Exception();
        }

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
        /// Меняет элементы местами по ссылкам на них.
        /// </summary>
        public static C Swap<C, T>(this C collection, T left, T right) where C : IEnumerable<T>
        {
            Validate();

            int leftIndex = collection.ToList().IndexOf(left);
            int rightIndex = collection.ToList().IndexOf(right);

            return (C) collection.Swap(leftIndex, rightIndex);

            void Validate()
            {
                if (!collection.Contains(left))
                {
                    throw new Exception($"collection doesn't contains left");
                }

                if (!collection.Contains(right))
                {
                    throw new Exception($"collection doesn't contains right");
                }
            }
        }

        /// <summary>
        /// Меняет элементы местами по индексу.
        /// </summary>
        public static C Swap<C, T>(this C collection, int leftIndex, int rightIndex) where C : IEnumerable<T>
        {
            Validate();

            return (C) collection.Swap(leftIndex, rightIndex);

            void Validate()
            {
                if (leftIndex >= collection.Count())
                {
                    throw new Exception($"leftIndex of collection is outside the bounds of the array");
                }

                if (rightIndex >= collection.Count())
                {
                    throw new Exception($"rightIndex of collection is outside the bounds of the array");
                }
            }
        }

        /// <summary>
        /// Перемешивает элементы коллекции в случайном порядке.
        /// </summary>
        public static IEnumerable<T> Shake<T>(this IEnumerable<T> collection)
        {
            var random = new Random();
            return collection.Shake(random);
        }

        public static IEnumerable<T> Shake<T>(this IEnumerable<T> collection, int seed)
        {
            var random = new Random(seed);
            return collection.Shake(random);
        }

        public static IEnumerable<T> Shake<T>(this IEnumerable<T> collection, Random random)
        {
            return collection.OrderBy(value => random.Next());
        }

        /// <summary>
        /// Возвращает count последних элементов коллекции.
        /// </summary>
        public static IEnumerable<T> Last<T>(this IEnumerable<T> collection, int count)
        {
            if (collection.Count() > count)
            {
                return collection.ToList().GetRange(collection.Count() - 1 - count, count);
            }
            else
            {
                return collection;
            }
        }

        public static IEnumerable<T> Without<T>(this IEnumerable<T> collection, IEnumerable<T> without)
        {
            return collection.Where(value => !without.Contains(value));
        }

        public static IEnumerable<T> Without<T>(this IEnumerable<T> collection, params T[] without)
        {
            return collection.Where(value => !without.Contains(value));
        }

        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> collection, Comparison<T> comparison)
        {
            var list = collection.ToList();
            foreach (var self in list)
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

        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> collection, Func<T, int> func)
        {
            return collection.Distinct((left, right) => func(right) - func(left));
        }

        /// <summary>
        /// Проверяет, идут ли хоть некоторые элементы друг за другом последовательно
        /// </summary>
        public static bool IsSomeSuccessively(this IEnumerable<int> collection, out List<List<int>> sequences)
        {
            var list = collection.ToList();

            sequences = new List<List<int>>();

            List<int> currentSequence = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == list.Last()) break;

                if (currentSequence.Count == 0)
                {
                    if (list[i + 1] - list[i] == 1)
                    {
                        currentSequence.Add(list[i]);
                    }
                }
                else if (list[i] - list[i - 1] == 1)
                {
                    currentSequence.Add(list[i]);
                }
                else if (currentSequence.Count != 0 || i == list.Count - 1)
                {
                    sequences.Add(currentSequence);
                    currentSequence.Clear();
                }
            }

            return sequences.Count > 0;
        }

        /// <summary>
        /// Проверяет, идут ли все элементы друг за другом последовательно (1-2-3 / 6-7-8...)
        /// </summary>
        public static bool IsAllSuccessively(this IEnumerable<int> collection)
        {
            var list = collection.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                if (i == 0) continue;
                if (list[i] - list[i - 1] != 1) return false;
            }

            return true;
        }

        public static bool IsAllSuccessively<T>(this IEnumerable<T> collection, Func<T, int> func)
        {
            return IsAllSuccessively(collection.Select(value => func.Invoke(value)));
        }

        public static IEnumerable<T> GetNonRepeatingRandom<T>(this IEnumerable<T> collection, int count)
        {
            if (count > collection.Count())
            {
                throw new Exception("Число запрошенных элементов больше количества элементов в коллекции");
            }

            var distinct = collection.Distinct();

            if (count > distinct.Count())
            {
                throw new Exception("Число запрошенных элементо больше количества неповторяющихся элементов в коллекции");
            }

            distinct = distinct.Shake();

            return distinct.Take(count);
        }

        /// <summary>
        /// Добавляет элемент к коллекции и возвращает его же (Fluent-pattern)
        /// </summary>
        public static T AddTo<T>(this T element, ICollection<T> collection)
        {
            collection.Add(element);
            return element;
        }

        /// <summary>
        /// Метод, созданный с целью сократить дублирование кода.
        /// </summary>
        private static IEnumerable<T> Swap<T>(this IEnumerable<T> collection, int leftIndex, int rightIndex)
        {
            var array = collection.ToArray();

            T temp = array[leftIndex];
            array[leftIndex] = array[rightIndex];
            array[rightIndex] = temp;

            return array;
        }

        /// <summary>
        /// Возвращает коллекцию с одним элементом.
        /// </summary>
        public static IEnumerable<T> AsSingleCollection<T>(this T self)
        {
            var array = new T[1]
            {
                self
            };

            return array.AsEnumerable();
        }
    }
}