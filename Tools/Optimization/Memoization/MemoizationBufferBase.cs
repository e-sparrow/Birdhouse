using System;
using System.Collections.Generic;
using Birdhouse.Common.Extensions;
using Birdhouse.Common.Helpers;
using Birdhouse.Tools.Optimization.Memoization.Interfaces;
using Birdhouse.Tools.Substitution;
using Birdhouse.Tools.Substitution.Enums;
using Birdhouse.Tools.Substitution.Interfaces;
using Birdhouse.Tools.Tense.Expiration.Interfaces;

namespace Birdhouse.Tools.Optimization.Memoization
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

            var method = SubstitutionHelper.CreateSubstitutionMethod(substitutionOperator, ESubstitutionType.Forget);
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
            var result = GetOrCreate(key, create, CreateTerm());
            return result;
        }

        public TValue GetOrCreate(TKey key, Func<TValue> create, ITerm term)
        {
            var isExist = _dictionary.ContainsKey(key);
            if (!isExist)
            {
                var element = new MemoizationElement<TValue>(create.Invoke(), term);
                var pair = new KeyValuePair<TKey, IMemoizationElement<TValue>>(key, element);
                
                _substitutionController.Add(pair);
            }
            
            var result = _dictionary[key].Value;
            return result;
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