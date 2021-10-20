using System.Reflection;

namespace ESparrow.Utils.Reflection.MutableMembers.Adapters
{
    public class PropertyToMutableAdapter : ToMutableAdapterBase<PropertyInfo>
    {
        public PropertyToMutableAdapter(PropertyInfo propertyInfo) : base(propertyInfo, propertyInfo.Name)
        {
            
        }
        
        public override void SetValue(object subject, object value)
        {
            FieldInfo.SetValue(subject, value);
        }

        public override object GetValue(object subject)
        {
            return FieldInfo.GetValue(subject);
        }

        protected override bool IsValidMutable(PropertyInfo mutable)
        {
            return MutableValidator.IsValidProperty(mutable);
        }
    }
}