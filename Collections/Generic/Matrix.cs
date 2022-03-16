using System.Collections.Generic;
using ESparrow.Utils.Generic.Vectors.Interfaces;

namespace ESparrow.Utils.Collections.Generic
{
    public class Matrix<TValue, TIndex> : MatrixBase<TValue, TIndex>
    {
        public Matrix() : base(new Dictionary<IVector<TIndex>, TValue>())
        {
        
        }
    }
}
