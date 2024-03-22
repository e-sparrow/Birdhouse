using System;
using Birdhouse.Features.Processors.Interfaces;
using Birdhouse.Features.Registries;
using Birdhouse.Features.Registries.Interfaces;

namespace Birdhouse.Features.Processors
{
    public class AggregatorRegistry<T>
        : IReadOnlyProcessor<T>, IRegistry<Aggregator<T>>
    {
        private readonly IRegistryEnumerable<Aggregator<T>> _aggregators 
            = new RegistryEnumerable<Aggregator<T>>();
        
        public T Process(T source)
        {
            foreach (var aggregator in _aggregators)
            {
                source = aggregator.Invoke(source);
            }

            return source;
        }

        public IDisposable Register(Aggregator<T> element)
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