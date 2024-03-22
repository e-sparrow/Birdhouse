using System;
using System.Collections.Generic;
using System.Linq;
using Birdhouse.Common.Extensions;
using Birdhouse.Tools.Filtering.Interfaces;
using Birdhouse.Features.Processors;

namespace Birdhouse.Tools.Filtering
{
    public abstract class PriorityBasedFilterBase<T> : IFilter<IEnumerable<T>, T>
    {
        protected PriorityBasedFilterBase(int count, int minPriority)
        {
            _count = count;
            _minPriority = minPriority;
        }

        public event Aggregator<IEnumerable<T>> OnProcess = _ => _;
        
        private readonly int _count;
        private readonly int _minPriority;

        protected abstract int GetPriority(T self);
        
        public IEnumerable<T> Process(IEnumerable<T> source)
        {
            var dictionary = source.ToDictionary(value => value, GetPriority);
            
            var filtered = dictionary
                .Where(pair => pair.Value >= _minPriority)
                .OrderBy(pair => pair.Value);
            
            var count = Math.Min(filtered.Count(), _count);
            var counted = filtered.Take(count);
            var keys = counted.ToDictionary().Keys;
            
            var result = OnProcess.Invoke(keys);
            return result;
        }
    }
}