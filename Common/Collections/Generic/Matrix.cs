using System.Collections.Generic;
using Birdhouse.Common.Generic.Vectors.Interfaces;

namespace Birdhouse.Common.Collections.Generic
{
    public class Matrix<TValue, TIndex> : MatrixBase<TValue, TIndex>
    {
        public Matrix() : base(new Dictionary<IVector<TIndex>, TValue>())
        {
        
        }
    }
}
