using System.Collections.Generic;
using System.Linq;
using ESparrow.Utils.Collections.Generic.Interfaces;
using ESparrow.Utils.Generic.Pairs.Interfaces;

namespace ESparrow.Utils.Extensions
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

        public static IMultiDictionary<TKey, TValue> AsMultiDictionary<TKey, TValue>
            (this IEnumerable<IPair<TKey, TValue>> self)
        {
            var select = self.Select(value => value.AsKeyValuePair());
            var dictionary = select.ToMultiDictionary();

            return dictionary;
        }

        public static IMultiDictionary<TKey, TValue> AsMultiDictionary<TKey, TValue>
            (this IEnumerable<IPair<TKey, IReadOnlyCollection<TValue>>> self)
        {
            var select = self.Select(value => value.AsKeyValuePair());
            var dictionary = select.ToMultiDictionary();

            return dictionary;
        }
    }
}