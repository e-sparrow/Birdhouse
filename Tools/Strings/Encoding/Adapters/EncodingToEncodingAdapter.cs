using System.Text;
using ESparrow.Utils.Tools.Strings.Encoding.Enums;

namespace ESparrow.Utils.Tools.Strings.Encoding.Adapters
{
    public class EncodingToEncodingAdapter : ToEncodingAdapterBase<System.Text.Encoding>
    {
        public EncodingToEncodingAdapter(System.Text.Encoding value, EEncodingType type) : base(value)
        {
            Type = type;
        }

        protected override string Encode(System.Text.Encoding subject, byte[] value)
        {
            return subject.GetString(value);
        }

        public override EEncodingType Type { get; }
    }
}
