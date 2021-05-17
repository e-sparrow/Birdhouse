using System;
using System.Linq;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace ESparrow.Utils.Extensions
{
    /// <summary>
    /// Класс расширений для коллекций, наследуемых от интерфейса IEnumerable;
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Получает случайный элемент коллекции.
        /// </summary>
        public static T GetRandom<T>(this IEnumerable<T> collection)
        {
            var array = collection.ToArray();
            return array[Random.Range(0, array.Length)];
        }

        /// <summary>
        /// Получает случайный элемент из коллекции, учитывая его вес, за который можно принять любое float, int или double число.
        /// </summary>
        public static T GetWeighedRandom<T>(this IEnumerable<T> collection, Func<T, double> weight)
        {
            var array = collection.ToArray();

            double sum = array.Sum(value => weight(value));
            double random = Random.Range(0f, (float) sum);

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
            foreach (var element in collection)
            {
                collection = collection.Swap(element, collection.GetRandom());
            }

            return collection;
        }

        /// <summary>
        /// Возвращает count последних элементов коллекции.
        /// </summary>
        public static IEnumerable<T> Last<T>(this IEnumerable<T> collection, int count)
        {
            if (collection.Count() > count)
            {
                return collection.ToList().GetRange(collection.Count() - 1 - count, count).AsEnumerable();
            }
            else
            {
                return collection;
            }
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

            return array.AsEnumerable();
        }
    }
}
