using System.Text;

namespace Birdhouse.Common.Binaries
{
    public static class ByteExtensions
    {
        public static byte[] ToBytes(this string self, Encoding encoding = null)
        {
            encoding ??= Encoding.Default;
            
            var result = encoding.GetBytes(self);
            return result;
        }

        public static string BytesToString(this byte[] self, Encoding encoding = null)
        {
            encoding ??= Encoding.Default;

            var result = encoding.GetString(self);
            return result;
        }

        public static byte[] ToBytes(this bool self)
        {
            var result = new byte[] { (byte) (self ? 1 : 0) };
            return result;
        }

        public static bool BytesToBool(this byte[] self)
        {
            var result = self.Length != 0 && self[0] == 1;
            return result;
        }
    }
}