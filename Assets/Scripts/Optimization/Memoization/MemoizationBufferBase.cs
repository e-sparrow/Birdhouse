using System;
using System.Collections.Generic;
using ESparrow.Utils.Extensions;
using ESparrow.Utils.Helpers;
using ESparrow.Utils.Optimization.Memoization.Interfaces;
using ESparrow.Utils.Tools.DateAndTime.Expiration.Interfaces;
using ESparrow.Utils.Tools.Substitution;
using ESparrow.Utils.Tools.Substitution.Enums;
using ESparrow.Utils.Tools.Substitution.Interfaces;
using ESparrow.Utils.Tools.Substitution.Methods;
using ESparrow.Utils.Tools.Substitution.Operators.Adapters;

namespace ESparrow.Utils.Optimization.Memoization
{
    public abstract class MemoizationBufferBase<TKey, TValue> : IMemoizationBuffer<TKey, TValue>
    {
        protected MemoizationBufferBase(IDictionary<TKey, IMemoizationElement<TValue>> dictionary, bool capacious, int capacity)
        {
            _dictionary = dictionary;
            _substitutionController = CreateSubstitutionController(_dictionary, capacious, capacity);
        }

        private readonly IDictionary<TKey, IMemoizationElement<TValue>> _dictionary;
        
        private readonly ISubstitutionController<KeyValuePair<TKey, IMemoizationElement<TValue>>> _substitutionController;

        private static ISubstitutionController<KeyValuePair<TKey, IMemoizationElement<TValue>>> CreateSubstitutionController
            (IDictionary<TKey, IMemoizationElement<TValue>> dictionary, bool capacious, int capacity)
        {
            var substitutionOperator = dictionary.AsSubstitutionOperator();

            ISubstitutionMethod<KeyValuePair<TKey, IMemoizationElement<TValue>>> method = SubstitutionHelper.CreateSubstitutionMethod(substitutionOperator, ESubstitutionType.Forget);
            if (capacious)
            {
                method = SubstitutionHelper.CreateCapaciousSubstitutionMethod(capacity, method, substitutionOperator);
            }

            var controller = SubstitutionHelper.CreateSubstitutionController(method);

            return controller;
        }

        protected abstract ITerm CreateTerm();

        public TValue GetOrCreate(TKey key, Func<TValue> create)
        {
            return GetOrCreate(key, create, CreateTerm());
        }

        public TValue GetOrCreate(TKey key, Func<TValue> create, ITerm term)
        {
            if (!_dictionary.ContainsKey(key))
            {
                var element = new MemoizationElement<TValue>(create.Invoke(), term);
                var pair = new KeyValuePair<TKey, IMemoizationElement<TValue>>(key, element);
                
                _substitutionController.Add(pair);
            }
            
            return _dictionary[key].Value;
        }

        public void Check()
        {
            foreach (var item in _dictionary)
            {
                if (item.Value.Term.Check())
                {
                    _dictionary.Remove(item.Key);
                }
            }
        }
    }
}