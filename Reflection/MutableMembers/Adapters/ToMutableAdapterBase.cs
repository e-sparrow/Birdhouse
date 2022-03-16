using System;
using ESparrow.Utils.Reflection.MutableMembers.Interfaces;

namespace ESparrow.Utils.Reflection.MutableMembers.Adapters
{
    public abstract class ToMutableAdapterBase<T> : IMutable
    {
        protected ToMutableAdapterBase(T mutable, string name)
        {
            _mutable = mutable;
            Name = name;
        }

        private readonly T _mutable;

        protected abstract void SetValue(T mutable, object subject, object value);
        protected abstract object GetValue(T mutable, object subject);

        public void SetValue(object subject, object value)
        {
            SetValue(_mutable, subject, value);
        }

        public object GetValue(object subject)
        {
            return GetValue(_mutable, subject);
        }

        public string Name
        {
            get;
        }
    }
}