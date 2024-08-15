namespace Birdhouse.Common.Logical
{
    public static class LogicalHelper
    {
        public static byte ToByte(this bool self)
        {
            var result = (byte) (self ? 1 : 0);
            return result;
        }

        public static bool FromByte(this byte self)
        {
            var result = self == 1;
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

        public static bool FromIntToBool(this int self)
        {
            var result = self == 1;
            return result;
        }
    }
}