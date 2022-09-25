using System.Collections.Generic;

namespace Birdhouse.Tools.Filtering.Interfaces
{
    public interface IFilter<T>
    {
        IEnumerable<T> Filtrate(IEnumerable<T> source);
    }
}