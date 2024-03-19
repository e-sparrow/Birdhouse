using System.Reflection;

namespace Birdhouse.Common.Reflection.MutableMembers.Adapters
{
    public sealed class PropertyToReadableAdapter
        : ToReadableAdapterBase<PropertyInfo>
    {
        public PropertyToReadableAdapter(PropertyInfo readable) 
            : base(readable)
        {
            
        }

        protected override object GetValue(PropertyInfo readable, object target)
        {
            var result = readable.GetValue(target);
            return result;
        }
    }
}