using System.IO;
using System.Threading.Tasks;
using Birdhouse.Tools.Serialization.Interfaces;

namespace Birdhouse.Common.Extensions
{
    public static class SerializationExtensions
    {
        public static void Serialize<T>(this T self, ISerializationController controller)
        {
            controller.Serialize(self);
        }

        public static async Task<T> Deserialize<T>(this ISerializationController controller)
        {
            return await controller.Deserialize<T>();
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