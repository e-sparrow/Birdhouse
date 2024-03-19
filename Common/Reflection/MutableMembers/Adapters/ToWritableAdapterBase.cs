using Birdhouse.Common.Reflection.MutableMembers.Interfaces;

namespace Birdhouse.Common.Reflection.MutableMembers.Adapters
{
    public abstract class ToWritableAdapterBase<T>
        : IWritable
    {
        protected ToWritableAdapterBase(T writable)
        {
            _writable = writable;
        }

        private readonly T _writable;

        protected abstract void SetValue(T writable, object target, object value);
        
        public void SetValue(object target, object value)
        {
            SetValue(_writable, target, value);
        }
    }
}