namespace ESparrow.Utils.Reflection.Adapters
{
    public class FieldToMutableMemberAdapter : ToMutableMemberAdapterBase
    {
        public FieldToMutableMemberAdapter(string memberName) : base(memberName)
        {

        }

        public override object GetValue(object subject)
        {
            var type = subject.GetType();
            var field = type.GetField(_memberName);
            var value = field.GetValue(subject);

            return value;
        }

        public override void SetValue(object value, object subject)
        {
            var type = subject.GetType();
            var field = type.GetField(_memberName);

            field.SetValue(value, subject);
        }
    }
}
