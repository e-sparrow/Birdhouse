using System.Collections.Generic;
using System.Text;
using ESparrow.Utils.Tools.TextEncoding.Adapters;
using ESparrow.Utils.Tools.TextEncoding.Enums;
using ESparrow.Utils.Tools.TextEncoding.Interfaces;

namespace ESparrow.Utils.Helpers
{
    public static class EncodingHelper
    {
        private static readonly List<IEncoding> Encodings = new List<IEncoding>()
        {
            new EncodingToEncodingAdapter(Encoding.Default, EEncodingType.Default),
            new EncodingToEncodingAdapter(Encoding.Unicode, EEncodingType.Unicode),
            new EncodingToEncodingAdapter(Encoding.BigEndianUnicode, EEncodingType.BigEndianUnicode),
            new EncodingToEncodingAdapter(Encoding.UTF7, EEncodingType.UTF7),
            new EncodingToEncodingAdapter(Encoding.UTF8, EEncodingType.UTF8),
            new EncodingToEncodingAdapter(Encoding.UTF32,EEncodingType.UTF32),
            new EncodingToEncodingAdapter(Encoding.ASCII, EEncodingType.ASCII)
        };

        public static IEncoding GetEncoding(EEncodingType type)
        {
            return Encodings.Find(value => value.Type == type);
        }
    }
}
