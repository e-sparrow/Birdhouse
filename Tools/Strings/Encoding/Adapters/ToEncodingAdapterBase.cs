using System.Linq;
using ESparrow.Utils.Extensions;
using ESparrow.Utils.Tools.Strings.Encoding.Enums;
using ESparrow.Utils.Tools.Strings.Encoding.Interfaces;

namespace ESparrow.Utils.Tools.Strings.Encoding.Adapters
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
