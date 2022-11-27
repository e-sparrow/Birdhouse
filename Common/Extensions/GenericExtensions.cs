using System.Collections.Generic;
using System.Linq;
using Birdhouse.Common.Collections.Generic.Interfaces;
using Birdhouse.Common.Generic.Pairs.Interfaces;

namespace Birdhouse.Common.Extensions
{
    public static class GenericExtensions
    {
        public static KeyValuePair<TKey, TValue> AsKeyValuePair<TKey, TValue>(this IPair<TKey, TValue> self)
        {
            return new KeyValuePair<TKey, TValue>(self.Key, self.Value);
        }

        public static IDictionary<TKey, TValue> AsDictionary<TKey, TValue>
            (this IEnumerable<IPair<TKey, TValue>> self, bool replace = false)
        {
            var select = self.Select(value => value.AsKeyValuePair());
            var dictionary = select.ToDictionary(replace);
            
            return dictionary;
        }
    }
}