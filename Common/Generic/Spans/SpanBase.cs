using Birdhouse.Common.Generic.Spans.Interfaces;

namespace Birdhouse.Common.Generic.Spans
{
    public abstract class SpanBase<T> : ISpan<T>
    {
        protected SpanBase(T min, T max)
        {
            Min = min;
            Max = max;
        }

        public T Min
        {
            get;
        }

        public T Max
        {
            get;
        }
    }
}