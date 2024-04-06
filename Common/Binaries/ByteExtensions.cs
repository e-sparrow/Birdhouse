using System.Text;

namespace Birdhouse.Common.Binaries
{
    public static class ByteExtensions
    {
        public static byte[] ToBytes(this string self, Encoding encoding = null)
        {
            encoding ??= Encoding.Unicode;
            
            var result = encoding.GetBytes(self);
            return result;
        }

        public static string BytesToString(this byte[] self, Encoding encoding = null)
        {
            encoding ??= Encoding.Unicode;

            var result = encoding.GetString(self);
            return result;
        }
    }
}