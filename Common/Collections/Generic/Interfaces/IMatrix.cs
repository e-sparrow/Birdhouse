using System.Collections.Generic;
using Birdhouse.Common.Generic.Vectors.Interfaces;

namespace Birdhouse.Common.Collections.Generic.Interfaces
{
    public interface IMatrix<TElement, TIndexer> : IDictionary<IVector<TIndexer>, TElement>
    {
        
    }
}