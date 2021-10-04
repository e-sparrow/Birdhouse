using System;
using System.Reflection;

namespace ESparrow.Utils.Patterns.Observer.Interfaces
{
    public interface IMemberObserver
    {
        public event Action<string, object, object> OnMemberChanged;

        public string Name
        {
            get;
        }

        public MemberTypes Type
        {
            get;
        }

        public void Check(object value);
    }
}
