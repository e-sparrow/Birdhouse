using Birdhouse.Common.Reflection.MutableMembers.Interfaces;

namespace Birdhouse.Common.Reflection.MutableMembers
{
    public class Mutable
        : IMutable
    {
        public Mutable(IWritable writable, IReadable readable)
        {
            _writable = writable;
            _readable = readable;
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