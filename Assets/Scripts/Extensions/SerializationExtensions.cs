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
    }
}