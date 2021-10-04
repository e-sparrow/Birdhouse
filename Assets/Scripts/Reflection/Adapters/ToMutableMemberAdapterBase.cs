using ESparrow.Utils.Reflection.Interfaces;

namespace ESparrow.Utils.Reflection.Adapters
{
    public abstract class ToMutableMemberAdapterBase : IMutableMember
    {
        protected readonly string _memberName;

        public ToMutableMemberAdapterBase(string memberName)
        {
            _memberName = memberName;
        }

        public abstract object GetValue(object subject);
        public abstract void SetValue(object value, object subject);
    }
}
