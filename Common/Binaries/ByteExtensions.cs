using System;
using System.Collections;
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

        // https://stackoverflow.com/a/560131
        public static byte ConvertToByte(this BitArray self)
        {
            if (self.Count != 8)
            {
                throw new ArgumentException();
            }
            
            var bytes = new byte[1];
            self.CopyTo(bytes, 0);
            
            return bytes[0];
        }

        // TODO: Check
        public static byte[] ConvertToBytes(this BitArray self)
        {
            var bytes = new byte[(int) Math.Ceiling(self.Count / 8.0)];
            self.CopyTo(bytes, 0);

            return bytes;
        }
    }
}