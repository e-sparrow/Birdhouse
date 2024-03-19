using System.Reflection;
using Birdhouse.Common.Reflection.MutableMembers.Interfaces;

namespace Birdhouse.Common.Reflection.MutableMembers.Adapters
{
    public sealed class FieldToMutableAdapter
        : IMutable
    {
        public FieldToMutableAdapter(FieldInfo fieldInfo)
        {
            _writable = new FieldToWritableAdapter(fieldInfo);
            _readable = new FieldToReadableAdapter(fieldInfo);
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