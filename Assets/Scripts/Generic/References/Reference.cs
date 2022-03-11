using System;

namespace ESparrow.Utils.Generic.References
{
    public class Reference<T> : ReferenceBase<T>
    {
        public Reference(Func<T> get, Action<T> set) : base(get, set)
        {
            
        }
    }
}