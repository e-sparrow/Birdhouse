using System;
using System.Collections.Generic;
using System.Linq;
using Birdhouse.Common.Extensions;
using Birdhouse.Tools.Filtering.Interfaces;
using Birdhouse.Tools.Processors;

namespace Birdhouse.Tools.Filtering
{
    public abstract class PriorityBasedFilterBase<TEnumerable, TElement> 
        : ProcessorBase<TEnumerable>, IFilter<TEnumerable, TElement>
        where TEnumerable : IEnumerable<TElement>
    {
        protected PriorityBasedFilterBase(int count = -1, int minPriority = 0)
        {
            _count = count;
            _minPriority = minPriority;
        }
        
        private readonly int _count;
        private readonly int _minPriority;

        protected abstract int GetPriority(TElement self);
        protected abstract TEnumerable CastBack(IEnumerable<TElement> enumerable);

        protected override TEnumerable ProcessInternal(TEnumerable source)
        {
            var dictionary = source.ToDictionary(value => value, GetPriority);
            var filtered = dictionary.Where(pair => pair.Value > _minPriority);
            
            var realCount = filtered.Count();
            var count = _count > 0 ? Math.Min(realCount, _count) : realCount;
            var counted = filtered.Take(count);
            
            var keys = counted.ToDictionary().Keys;

            var result = CastBack(keys);
            return result;
        }
    }
}