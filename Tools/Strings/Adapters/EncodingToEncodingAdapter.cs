using System.Text;
using ESparrow.Utils.Tools.TextEncoding.Enums;

namespace ESparrow.Utils.Tools.TextEncoding.Adapters
{
    public class EncodingToEncodingAdapter : ToEncodingAdapterBase<Encoding>
    {
        public EncodingToEncodingAdapter(Encoding value, EEncodingType type) : base(value)
        {
            Type = type;
        }

        protected override string Encode(Encoding subject, byte[] value)
        {
            return subject.GetString(value);
        }

        public override EEncodingType Type { get; }
    }
}
