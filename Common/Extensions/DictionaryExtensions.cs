using System.Collections.Generic;

namespace Birdhouse.Common.Extensions
{
    public static class DictionaryExtensions
    {
        public static void AddRange<TKey, TValue>
            (this IDictionary<TKey, TValue> self, IDictionary<TKey, TValue> other)
        {
            foreach (var item in other)
            {
                self.Add(item);
            }
        }
    }
}