using System;
using System.Collections.Generic;
using Birdhouse.Features.Cases.Enums;
using Birdhouse.Features.Cases.Interfaces;
using Birdhouse.Tools.Optimization.Memoization.Interfaces;

namespace Birdhouse.Features.Cases
{
    public abstract class CaseStorageBase<TValue, TCase> : ICaseStorage<TValue, TCase>
    {
        private readonly IMemoizationBuffer<TValue, IDictionary<TValue, TCase>> _buffer;

        protected abstract TValue GetOrCreate(TValue source, TCase @case, ICaseGetParams @params);
        
        public string GetValue(string source, ERussianCase @case, ICaseGetParams @params)
        {
            throw new NotImplementedException();
        }

        public TValue GetValue(TValue source, TCase @case, ICaseGetParams @params)
        {
            throw new System.NotImplementedException();
        }
    }
}