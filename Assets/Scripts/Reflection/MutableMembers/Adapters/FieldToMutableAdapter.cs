using System.Reflection;

namespace ESparrow.Utils.Reflection.MutableMembers.Adapters
{
    public class FieldToMutableAdapter : ToMutableAdapterBase<FieldInfo>
    {
        public FieldToMutableAdapter(FieldInfo fieldInfo) : base(fieldInfo, fieldInfo.Name)
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

        protected override bool IsValidMutable(FieldInfo mutable)
        {
            return MutableValidator.IsValidField(mutable);
        }
    }
}