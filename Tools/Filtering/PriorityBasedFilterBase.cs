using System;
using System.Collections.Generic;
using System.Linq;
using Birdhouse.Common.Extensions;
using Birdhouse.Tools.Filtering.Interfaces;

namespace Birdhouse.Tools.Filtering
{
    public abstract class PriorityBasedFilterBase<T> : IFilter<T>
    {
        protected PriorityBasedFilterBase(int count, int minPriority)
        {
            _count = count;
            _minPriority = minPriority;
        }

        private readonly int _count;
        private readonly int _minPriority;

        protected abstract int GetPriority(T self);
        
        public IEnumerable<T> Filtrate(IEnumerable<T> source)
        {
            var dictionary = source.ToDictionary(value => value, GetPriority);
            
            var filtered = dictionary
                .Where(pair => pair.Value >= _minPriority)
                .OrderBy(pair => pair.Value);
            
            var count = Math.Min(filtered.Count(), _count);
            var counted = filtered.Take(count);
            var result = counted.ToDictionary().Keys;
            
            return result;
        }
    }
}