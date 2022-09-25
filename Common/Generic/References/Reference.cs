using System;
using Birdhouse.Common.Generic.References;

namespace Birdhouse.Generic.References
{
    public class Reference<T> : ReferenceBase<T>
    {
        public Reference(Func<T> get, Action<T> set) : base(get, set)
        {
            
        }
    }
}