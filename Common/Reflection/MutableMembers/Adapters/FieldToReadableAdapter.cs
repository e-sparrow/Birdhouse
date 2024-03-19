using System.Reflection;

namespace Birdhouse.Common.Reflection.MutableMembers.Adapters
{
    public sealed class FieldToReadableAdapter
        : ToReadableAdapterBase<FieldInfo>
    {
        public FieldToReadableAdapter(FieldInfo readable) 
            : base(readable)
        {
            
        }

        protected override object GetValue(FieldInfo readable, object target)
        {
            var result = readable.GetValue(target);
            return result;
        }
    }
}