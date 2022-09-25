using System.Collections.Generic;
using Birdhouse.Common.Generic.Spans;

namespace Birdhouse.Common.Collections.Generic.Interfaces
{
    public interface IIntervalDictionary : IEnumerable<SpanBase<float>>
    {
        /* TODO: f.e.: _dictionary.AddInterval(new Interval(0f, 0,5f), value);
         TODO: thus, _dictionary[0.1f] equals _dictionary[0.25f] and other */
    }
}