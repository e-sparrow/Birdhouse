using System;
using Birdhouse.Features.Processors.Interfaces;
using Birdhouse.Features.Registries;
using Birdhouse.Features.Registries.Interfaces;

namespace Birdhouse.Features.Processors
{
    public class AggregatorRegistry<T>
        : IReadOnlyProcessor<T>, IRegistry<Aggregator<T>>
    {
        private readonly IRegistryEnumerable<Aggregator<T>> _evaluators 
            = new RegistryEnumerable<Aggregator<T>>();
        
        public T Process(T source)
        {
            foreach (var evaluator in _evaluators)
            {
                source = evaluator.Invoke(source);
            }

            return source;
        }

        public IDisposable Register(Aggregator<T> element)
        {
            var result = _evaluators.Register(element);
            return result;
        }

        public void Dispose()
        {
            _evaluators.Dispose();
        }
    }
}