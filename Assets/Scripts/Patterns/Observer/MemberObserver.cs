using System;
using System.Reflection;
using ESparrow.Utils.Patterns.Observer.Interfaces;

namespace ESparrow.Utils.Patterns.Observer
{
    public class MemberObserver : IMemberObserver
    {
        public event Action<string, object, object> OnMemberChanged;

        protected object _lastValue;

        protected readonly string _name;
        private readonly MemberTypes _type;

        public string Name => _name;
        public MemberTypes Type => _type;

        public MemberObserver(string name, MemberTypes type, object lastValue)
        {
            _name = name;
            _type = type;

            _lastValue = lastValue;
        }

        public void Check(object value)
        {
            if (!value.Equals(_lastValue))
            {
                ConfirmChange(value);
            }
        }

        protected void ConfirmChange(object value)
        {
            OnMemberChanged?.Invoke(_name, _lastValue, value);
            _lastValue = value;
        }
    }
}
