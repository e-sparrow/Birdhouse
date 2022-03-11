using System.Linq;
using ESparrow.Utils.Extensions;
using ESparrow.Utils.Tools.TextEncoding.Enums;
using ESparrow.Utils.Tools.TextEncoding.Interfaces;

namespace ESparrow.Utils.Tools.TextEncoding.Adapters
{
    public abstract class ToEncodingAdapterBase<T> : IEncoding
    {
        protected ToEncodingAdapterBase(T value)
        {
            _value = value;
        }

        private readonly T _value;

        protected abstract string Encode(T subject, byte[] value);
        
        public string Encode(byte[] value)
        {
            return Encode(_value, value);
        }

        public char Encode(byte value)
        {
            return Encode(value.AsSingleEnumerable().ToArray())[0];
        }

        public abstract EEncodingType Type
        {
            get;
        }
    }
}
