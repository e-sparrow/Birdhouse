using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Birdhouse.Common.Extensions
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// Creates Collection from Enumerable.
        /// </summary>
        /// <param name="self">Self enumerable</param>
        /// <typeparam name="T">Type of elements in enumerable</typeparam>
        /// <returns>Collection from IEnumerable</returns>
        public static ICollection<T> AsCollection<T>(this IEnumerable<T> self)
        {
            var result = new Collection<T>(self.ToList());
            return result;
        }

        public static ICollection<T> RemoveWhere<T>(this ICollection<T> self, Predicate<T> predicate)
        {
            foreach (var value in self)
            {
                var result = predicate.Invoke(value);
                if (!result)
                {
                    self.Remove(value);
                }
            }

            return self;
        }

        public static ICollection<T> AddRange<T>(this ICollection<T> self, IEnumerable<T> other)
        {
            foreach (var item in other)
            {
                self.Add(item);
            }

            return self;
        }
    }
}