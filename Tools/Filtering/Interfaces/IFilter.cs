using System.Collections.Generic;
using Birdhouse.Tools.Processors.Interfaces;

namespace Birdhouse.Tools.Filtering.Interfaces
{
    public interface IFilter<TEnumerable, TElement> : IProcessor<TEnumerable> 
        where TEnumerable : IEnumerable<TElement>
    {
        
    }
}