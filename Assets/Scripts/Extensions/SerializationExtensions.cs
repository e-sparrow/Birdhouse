using System.IO;
using ESparrow.Utils.Serialization.Interfaces;

namespace ESparrow.Utils.Extensions
{
    public static class SerializationExtensions
    {
        public static void Serialize<T>(this T self, ISerializationController controller)
        {
            controller.Serialize(self);
        }

        public static T Deserialize<T>(this ISerializationController controller)
        {
            return controller.Deserialize<T>();
        }

        public static bool IsEmpty(this Stream stream)
        {
            return stream.Length == 0;
        }

        public static bool IsNotEmpty(this Stream stream)
        {
            return !stream.IsEmpty();
        }
    }
}