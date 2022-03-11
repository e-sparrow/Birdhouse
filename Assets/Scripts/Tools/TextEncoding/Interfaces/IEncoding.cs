using ESparrow.Utils.Tools.TextEncoding.Enums;

namespace ESparrow.Utils.Tools.TextEncoding.Interfaces
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
