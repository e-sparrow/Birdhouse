using System.Collections.Generic;
using ESparrow.Utils.Generic.Vectors.Interfaces;

namespace ESparrow.Utils.Collections.Generic.Interfaces
{
    public interface IMatrix<TElement, TIndexer> : IDictionary<IVector<TIndexer>, TElement>
    {
        
    }
}