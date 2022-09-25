using System;
using Birdhouse.Common.Reflection.MutableMembers.Interfaces;
using Birdhouse.Education.Patterns.Observer.Interfaces;

namespace Birdhouse.Education.Patterns.Observer
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
