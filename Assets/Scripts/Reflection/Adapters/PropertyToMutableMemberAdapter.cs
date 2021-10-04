namespace ESparrow.Utils.Reflection.Adapters
{
    public class PropertyToMutableMemberAdapter : ToMutableMemberAdapterBase
    {
        public PropertyToMutableMemberAdapter(string memberName) : base(memberName)
        {

        }

        public override object GetValue(object subject)
        {
            var type = subject.GetType();
            var property = type.GetProperty(_memberName);
            var value = property.GetValue(subject);

            return value;
        }

        public override void SetValue(object value, object subject)
        {
            var type = subject.GetType();
            var property = type.GetProperty(_memberName);

            property.SetValue(value, subject);
        }
    }
}
