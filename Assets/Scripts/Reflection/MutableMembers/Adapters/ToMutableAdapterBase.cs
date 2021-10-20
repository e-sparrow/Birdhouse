using System;
using ESparrow.Utils.Reflection.MutableMembers.Interfaces;

namespace ESparrow.Utils.Reflection.MutableMembers.Adapters
{
    public abstract class ToMutableAdapterBase<TMutable> : IMutable
    {
        protected ToMutableAdapterBase(TMutable fieldInfo, string name)
        {
            Validate(fieldInfo);
            
            FieldInfo = fieldInfo;
            _name = name;
        }

        protected readonly TMutable FieldInfo;
        
        private readonly string _name;

        public abstract void SetValue(object subject, object value);
        public abstract object GetValue(object subject);

        protected abstract bool IsValidMutable(TMutable mutable);

        private void Validate(TMutable mutable)
        {
            if (IsValidMutable(mutable)) return;
            
            const string message = "This mutable is not valid!";
            throw new ArgumentException(message, nameof(mutable));
        }

        public string Name => _name;
    }
}