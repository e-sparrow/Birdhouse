using System.Reflection;

namespace Birdhouse.Common.Reflection.MutableMembers.Adapters
{
    public sealed class PropertyToWritableAdapter
        : ToWritableAdapterBase<PropertyInfo>
    {
        public PropertyToWritableAdapter(PropertyInfo propertyInfo)
            : base(propertyInfo)
        {
            
        }

        protected override void SetValue(PropertyInfo writable, object target, object value)
        {
            writable.SetValue(target, value);
        }
    }
}