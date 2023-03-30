using System.Collections.Generic;
using Birdhouse.Tools.Filtering.Interfaces;

namespace Birdhouse.Tools.Detection.Interfaces
{
    public interface IDetector<T>
    {
        IEnumerable<T> Detect(IFilter<T> filter);
    }
}