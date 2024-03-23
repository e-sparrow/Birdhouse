using System;
using Birdhouse.Features.Aggregators.Interfaces;
using Birdhouse.Features.Registries;
using Birdhouse.Features.Registries.Interfaces;

namespace Birdhouse.Features.Aggregators
{
    public class AggregatorRegistry<T>
        : IReadOnlyAggregator<T>, IRegistry<Aggregation<T>>
    {
        private readonly IRegistryEnumerable<Aggregation<T>> _aggregators 
            = new RegistryEnumerable<Aggregation<T>>();
        
        public T Process(T source)
        {
            foreach (var aggregator in _aggregators)
            {
                source = aggregator.Invoke(source);
            }

            return source;
        }

        public IDisposable Register(Aggregation<T> element)
        {
            var result = _aggregators.Register(element);
            return result;
        }

        public void Dispose()
        {
            _aggregators.Dispose();
        }
    }
}