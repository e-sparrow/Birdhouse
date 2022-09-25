using System;
using Birdhouse.Common.Generic.References.Interfaces;

namespace Birdhouse.Common.Generic.References
{
    public abstract class ReferenceBase<T> : IReference<T>
    {
        protected ReferenceBase(Func<T> get, Action<T> set)
        {
            _get = get;
            _set = set;
        }
        
        private readonly Func<T> _get;
        private readonly Action<T> _set;

        public T Value
        {
            get => _get.Invoke();
            set => _set.Invoke(value);
        }
    }
}
