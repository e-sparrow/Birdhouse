using System.Collections.Generic;
using Birdhouse.Features.Cases.Interfaces;

namespace Birdhouse.Features.Cases
{
    public class CaseGetter<TValue, TCase> : ICaseGetter<TValue, TCase>
    {
        public CaseGetter(IDictionary<TCase, TValue> dictionary)
        {
            _dictionary = dictionary;
        }

        private readonly IDictionary<TCase, TValue> _dictionary;

        public TValue GetCase(TCase @case)
        {
            var result = _dictionary[@case];
            return result;
        }
    }
}