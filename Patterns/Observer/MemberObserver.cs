using System;
using ESparrow.Utils.Patterns.Observer.Interfaces;
using ESparrow.Utils.Reflection.MutableMembers.Interfaces;

namespace ESparrow.Utils.Patterns.Observer
{
    public sealed class MemberObserver : IMemberObserver
    {
        public MemberObserver(IMutable mutable, object currentValue)
        {
            Mutable = mutable;
            _lastValue = currentValue;
        }

        public event Action<object, object> OnMemberChanged = (before, after) => { };
        
        private object _lastValue;
        
        public bool Check(object value)
        {
            if (value.Equals(_lastValue)) return false;
            
            OnMemberChanged.Invoke(_lastValue, value);
            
            _lastValue = value;
            return true;
        }

        public IMutable Mutable
        {
            get;
        }
    }
}
