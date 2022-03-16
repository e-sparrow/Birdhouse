using System.Reflection;

namespace ESparrow.Utils.Reflection.MutableMembers.Adapters
{
    public class PropertyToMutableAdapter : ToMutableAdapterBase<PropertyInfo>
    {
        public PropertyToMutableAdapter(PropertyInfo propertyInfo) : base(propertyInfo, propertyInfo.Name)
        {
            
        }
        
        protected override void SetValue(PropertyInfo mutable, object subject, object value)
        {
            mutable.SetValue(subject, value);
        }

        protected override object GetValue(PropertyInfo mutable, object subject)
        {
            return mutable.GetValue(subject);
        }
    }
}