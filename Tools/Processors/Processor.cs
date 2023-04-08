namespace Birdhouse.Tools.Processors
{
    public class Processor<T> : ProcessorBase<T>
    {
        protected override T ProcessInternal(T source)
        {
            return source;
        }
    }
}