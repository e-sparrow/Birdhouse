using System.Collections.Generic;

namespace Birdhouse.Common.Generic.Vectors
{
    public class Vector<T> : VectorBase<T>
    {
        public Vector(IList<T> list) : base(list)
        {
            
        }

        public Vector(params T[] values) : base(values)
        {
            
        }
    }
}
