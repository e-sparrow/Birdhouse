using Birdhouse.Common.Reflection.MutableMembers.Interfaces;

namespace Birdhouse.Common.Reflection.MutableMembers.Adapters
{
    public abstract class ToReadableAdapterBase<T>
        : IReadable
    {
        protected ToReadableAdapterBase(T readable)
        {
            _readable = readable;
        }

        private readonly T _readable;

        protected abstract object GetValue(T readable, object target);
        
        public object GetValue(object target)
        {
            var result = GetValue(_readable, target);
            return result;
        }
    }
}