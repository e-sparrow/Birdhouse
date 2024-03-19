﻿using System.Collections.Generic;
using Birdhouse.Features.Processors.Interfaces;

namespace Birdhouse.Features.Processors
{
    public abstract class ProcessorBase<T> 
        : IProcessor<T>
    {
        public event Evaluator<T> OnProcess
        {
            add => _evaluators.Add(value);
            remove => _evaluators.Remove(value);
        }

        private readonly IList<Evaluator<T>> _evaluators = new List<Evaluator<T>>();

        protected abstract T ProcessInternal(T source);
        
        public T Process(T source)
        {
            var processed = ProcessInternal(source);

            foreach (var evaluator in _evaluators)
            {
                processed = evaluator.Invoke(processed);
            }
            
            return processed;
        }
    }
}