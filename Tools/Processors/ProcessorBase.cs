using Birdhouse.Tools.Processors.Interfaces;

namespace Birdhouse.Tools.Processors
{
    public abstract class ProcessorBase<T> : IProcessor<T>
    {
        public event Evaluator<T> OnProcess = _ => _;

        protected abstract T ProcessInternal(T source);
        
        public T Process(T source)
        {
            var processed = ProcessInternal(source);

            var result = OnProcess.Invoke(processed);
            return result;
        }
    }
}