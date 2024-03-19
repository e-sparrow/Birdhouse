using System;
using Birdhouse.Features.Processors.Interfaces;
using Birdhouse.Features.Registries;
using Birdhouse.Features.Registries.Interfaces;

namespace Birdhouse.Features.Processors
{
    public class ProcessorRegistry<T>
        : IReadOnlyProcessor<T>, IRegistry<Evaluator<T>>
    {
        private readonly IRegistryEnumerable<Evaluator<T>> _evaluators 
            = new RegistryEnumerable<Evaluator<T>>();
        
        public T Process(T source)
        {
            foreach (var evaluator in _evaluators)
            {
                source = evaluator.Invoke(source);
            }

            return source;
        }

        public IDisposable Register(Evaluator<T> element)
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