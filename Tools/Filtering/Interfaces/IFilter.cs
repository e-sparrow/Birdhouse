using System.Collections.Generic;
using Birdhouse.Features.Aggregators.Interfaces;

namespace Birdhouse.Tools.Filtering.Interfaces
{
    public interface IFilter<TEnumerable, TElement> : IAggregator<TEnumerable> 
        where TEnumerable : IEnumerable<TElement>
    {
        
    }
}