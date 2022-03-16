using System.Reflection;

namespace ESparrow.Utils.Reflection.MutableMembers.Adapters
{
    public class FieldToMutableAdapter : ToMutableAdapterBase<FieldInfo>
    {
        public FieldToMutableAdapter(FieldInfo mutable) : base(mutable, mutable.Name)
        {
            
        }
        
        protected override void SetValue(FieldInfo mutable, object subject, object value)
        {
            mutable.SetValue(subject, value);
        }

        protected override object GetValue(FieldInfo mutable, object subject)
        {
            return mutable.GetValue(subject);
        }
    }
}