using System;
using System.Reflection;

namespace ESparrow.Utils.Patterns.Observer.Interfaces
{
    public interface IMemberObserver
    {
        event Action<string, object, object> OnMemberChanged;

        string Name
        {
            get;
        }

        MemberTypes Type
        {
            get;
        }

        void Check(object value);
    }
}
