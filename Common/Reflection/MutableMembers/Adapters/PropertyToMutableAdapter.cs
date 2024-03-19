using System.Reflection;
using Birdhouse.Common.Reflection.MutableMembers.Interfaces;

namespace Birdhouse.Common.Reflection.MutableMembers.Adapters
{
    public sealed class PropertyToMutableAdapter
        : IMutable
    {
        public PropertyToMutableAdapter(PropertyInfo propertyInfo)
        {
            _writable = new PropertyToWritableAdapter(propertyInfo);
            _readable = new PropertyToReadableAdapter(propertyInfo);
        }

        private readonly IWritable _writable;
        private readonly IReadable _readable;
        
        public void SetValue(object target, object value)
        {
            _writable.SetValue(target, value);
        }

        public object GetValue(object target)
        {
            var result = _readable.GetValue(target);
            return result;
        }
    }
}