using System.Collections.Generic;
using System.Linq;

namespace ESparrow.Utils.Tools.Substitution.Operators.Adapters
{
    public class DictionaryToSubstitutionOperatorAdapter<TKey, TValue> : SubstitutionOperatorBase<IDictionary<TKey, TValue>, KeyValuePair<TKey, TValue>>
    {
        public DictionaryToSubstitutionOperatorAdapter(IDictionary<TKey, TValue> enumerable) : base(enumerable)
        {
            _orderDictionary = new Dictionary<int, TKey>();

            var keys = enumerable.Keys.ToArray();
            for (int i = 0; i < keys.Length; i++)
            {
                _orderDictionary[i] = keys[i];
            }
        }

        private readonly IDictionary<int, TKey> _orderDictionary;

        protected override void InsertAt(int index, KeyValuePair<TKey, TValue> element, IDictionary<TKey, TValue> enumerable)
        {
            var key = element.Key;
            
            _orderDictionary[index] = key;
            enumerable[key] = element.Value;
        }

        protected override void RemoveAt(int index, IDictionary<TKey, TValue> enumerable)
        {
            if (_orderDictionary.ContainsKey(index))
            {
                var key = _orderDictionary[index];
                enumerable.Remove(key);

                _orderDictionary.Remove(index);
            }
        }
    }
}