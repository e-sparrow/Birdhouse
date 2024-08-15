using System.IO;
using System.Threading.Tasks;
using Birdhouse.Tools.Serialization.Interfaces;

namespace Birdhouse.Tools.Serialization
{
    public static class SerializationExtensions
    {
        public static TResult GetOrDefault<TKey, TResult>
            (this ISerializationStorage<TKey> self, TKey key, TResult @default)
        {
            var result = self.HasKey(key) ? self.Get<TResult>(key) : @default;
            return result;
        }
        
        public static async Task Serialize<T>(this T self, ISerializationController controller)
        {
            await controller.Serialize(self);
        }

        public static async Task<T> Deserialize<T>(this ISerializationController controller)
        {
            var result = await controller.Deserialize<T>();
            return result;
        }

        public static bool TryDeserialize<T>(this ISerializationController controller, out T value)
        {
            value = default;

            var result = controller.IsExist();
            if (result)
            {
                value = controller.Deserialize<T>().Result;
            }

            return result;
        }

        public static bool IsEmpty(this Stream stream)
        {
            var result = stream.Length == 0;
            return result;
        }

        public static bool IsNotEmpty(this Stream stream)
        {
            var result = !stream.IsEmpty();
            return result;
        }
    }
}