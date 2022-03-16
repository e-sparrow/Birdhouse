using System.Collections;
using System.Collections.Generic;
using ESparrow.Utils.Generic.Spans;

namespace ESparrow.Utils.Collections.Generic.Interfaces
{
    public interface IIntervalDictionary : IEnumerable<SpanBase<float>>
    {
        /* TODO: f.e.: _dictionary.AddInterval(new Interval(0f, 0,5f), value);
         TODO: thus, _dictionary[0.1f] equals _dictionary[0.25f] and other */
    }
}