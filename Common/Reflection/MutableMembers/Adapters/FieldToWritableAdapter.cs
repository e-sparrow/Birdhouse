using System.Reflection;

namespace Birdhouse.Common.Reflection.MutableMembers.Adapters
{
    public sealed class FieldToWritableAdapter
        : ToWritableAdapterBase<FieldInfo>
    {
        public FieldToWritableAdapter(FieldInfo writable) 
            : base(writable)
        {
            
        }

        protected override void SetValue(FieldInfo writable, object target, object value)
        {
            writable.SetValue(target, value);
        }
    }
}