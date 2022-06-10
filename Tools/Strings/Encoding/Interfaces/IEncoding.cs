using ESparrow.Utils.Tools.Strings.Encoding.Enums;

namespace ESparrow.Utils.Tools.Strings.Encoding.Interfaces
{
    public interface IEncoding
    {
        char Encode(byte value);
        string Encode(byte[] value);

        EEncodingType Type
        {
            get;
        }
    }
}
